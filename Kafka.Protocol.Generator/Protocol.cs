using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using Kafka.Protocol.Generator.Extensions;

namespace Kafka.Protocol.Generator
{
    internal class Protocol
    {
        private readonly HtmlDocument _definition;

        internal static Protocol Load(HtmlDocument definition)
        {
            return new Protocol(definition);
        }

        private Protocol(HtmlDocument definition)
        {
            _definition = definition;
            ErrorCodes = ParseErrorCodes(definition.DocumentNode);
            Requests = ParseMessages(definition.DocumentNode);
        }

        internal IDictionary<int, ErrorCode> ErrorCodes { get; }

        internal IDictionary<int, Message> Requests { get; }

        private const string ProtocolApiKeysXPath = "//*[contains(@id,'protocol_api_keys')]/..";

        private IDictionary<int, Message> ParseMessages(HtmlNode node)
        {
            var links = new Dictionary<string, HtmlNode>();

            var apiKeyMessageMaps = node
                .SelectFirst(ProtocolApiKeysXPath)
                .GetFirstSiblingNamed("table")
                .ParseTableNodeTo<ApiKeyMessageMap>()
                .ToDictionary(
                    request => request.Key);

            var messages = new Dictionary<int, Message>();
            foreach (var apiKeyMessageMap in apiKeyMessageMaps.Values)
            {
                var message = new Message(apiKeyMessageMap.Key, apiKeyMessageMap.Name);
                messages.Add(apiKeyMessageMap.Key, message);
                ParseRequestsForMessage(message.Name);
            }

            return messages;
        }

        private string GetProtocolRequestMethodXPathFor(string methodName) =>
            $"//*/pre[starts-with(text(),'{methodName} Request')]";

        private IDictionary<int, Method> ParseRequestsForMessage(string name)
        {
            var messageDefinitionNode = _definition
                .DocumentNode
                .SelectFirst(GetProtocolRequestMethodXPathFor(name));

            var definitionRows = messageDefinitionNode.InnerText.Split('\n');


            return null;
        }

        private const string ProtocolErrorCodesXPath = "//*[contains(@id,'protocol_error_codes')]/..";

        private static IDictionary<int, ErrorCode> ParseErrorCodes(HtmlNode node)
        {
            return node
                .SelectFirst(ProtocolErrorCodesXPath)
                .GetFirstSiblingNamed("table")
                .ParseTableNodeTo<ErrorCode>()
                .ToDictionary(
                    errorCode => errorCode.Code);
        }

    }

    internal class MethodParser
    {
        internal static Method Parse(Queue<char> buffer)
        {
            var methodSymbol = MethodSymbolParser.Parse(buffer);
            
            var symbolCollection = new SymbolCollection();
            var methodExpression = ExpressionParser.Parse(buffer, symbolCollection);
            
            while (buffer.Any())
            {
                RuleParser.Parse(buffer, ref symbolCollection);
            }

            return new Method
            {
                Name = methodSymbol.Name,
                Version = methodSymbol.Version,
                Type = methodSymbol.Type,
                Expression = methodExpression,
                Fields = symbolCollection.Values.ToList()
            };
        }
    }

    internal class MethodSymbolParser
    {
        private readonly Queue<char> _buffer;
        private readonly Queue<Func<char, bool>> _handlers;

        private MethodSymbolParser(Queue<char> buffer)
        {
            _buffer = buffer;
            _handlers = new Queue<Func<char, bool>>(new List<Func<char, bool>>
            {
                ParseName,
                ParseMethodType,
                ParseVersion
            });
            _handle = _handlers.Dequeue();
        }

        private string _name = "";
        private int _version;
        private MethodType _type;

        private string _tempBuffer = "";
        private Func<char, bool> _handle;

        internal static MethodSymbol Parse(Queue<char> buffer)
        {
            var methodSymbolParser = new MethodSymbolParser(buffer);
            while (methodSymbolParser.Next()) { }

            return new MethodSymbol
            {
                Name = methodSymbolParser._name,
                Version = methodSymbolParser._version,
                Type = methodSymbolParser._type
            };
        }

        private bool ParseName(char chr)
        {
            if (chr == ' ')
            {
                return false;
            }

            _name += chr;
            return true;
        }

        private bool ParseMethodType(char chr)
        {
            if (chr == ' ')
            {
                _type = (MethodType)Enum.Parse(typeof(MethodType), _tempBuffer);
                _tempBuffer = "";
                return false;
            }

            _tempBuffer += chr;
            return true;
        }

        private bool ParseVersion(char chr)
        {
            if (chr == ')')
            {
                _version = int.Parse(_tempBuffer.Split(' ')[1]);
                _tempBuffer = "";
                return false;
            }

            _tempBuffer += chr;
            return true;
        }
        
        private bool Next()
        {
            var chr = _buffer.Dequeue();

            var canHandleMore = _handle(chr);

            if (canHandleMore)
            {
                return true;
            }

            if (_handlers.Any())
            {
                _handle = _handlers.Dequeue();
                return true;
            }

            while (HasReachedDefinedAs(chr) == false)
            {
                chr = _buffer.Dequeue();
            }

            return false;
        }

        private bool HasReachedDefinedAs(char chr)
        {
            if (string.Concat(chr, _buffer.Peek()) == "=>")
            {
                _buffer.Dequeue();
                return true;
            }

            return false;
        }
    }

    internal class SymbolNameParser
    {
        private const string DefinedAs = "=>";
        private readonly Queue<char> _buffer;

        private SymbolNameParser(Queue<char> buffer)
        {
            _buffer = buffer;
        }

        private string _name = "";

        internal static string Parse(Queue<char> buffer)
        {
            var parser = new SymbolNameParser(buffer);

            while (parser.Next()) { }

            return parser._name;
        }

        private bool Next()
        {
            var chr = _buffer.Dequeue();
            if (HasReachedDefinedAs(chr))
            {
                _name = _name.Trim();
                return false;
            }

            _name += chr;
            return true;
        }

        private bool HasReachedDefinedAs(char chr)
        {
            if (string.Concat(chr, _buffer.Peek()) == DefinedAs)
            {
                _buffer.Dequeue();
                return true;
            }

            return false;
        }
    }

    internal class ExpressionParser
    {
        private readonly Queue<char> _buffer;
        private readonly SymbolCollection _symbolCollection;
        private const char End = '\n';

        private ExpressionParser(Queue<char> buffer, SymbolCollection symbolCollection)
        {
            _buffer = buffer;
            _symbolCollection = symbolCollection;
        }

        private Queue<SymbolSequence> Expression { get; } = new Queue<SymbolSequence>();
        private string _fieldExpressionBuffer = "";

        internal static Queue<SymbolSequence> Parse(Queue<char> buffer, SymbolCollection symbolCollection)
        {
            var parser = new ExpressionParser(buffer, symbolCollection);

            while (parser.Next()) { }

            return parser.Expression;
        }

        private bool Next()
        {
            if (_buffer.Any() == false)
            {
                AddCurrentExpression();
                return false;
            }

            var chr = _buffer.Dequeue();
            if (chr == End)
            {
                AddCurrentExpression();
                return false;
            }

            if (chr == ' ')
            {
                AddCurrentExpression();
                return true;
            }

            _fieldExpressionBuffer += chr;
            return true;
        }

        private void AddCurrentExpression()
        {
            var currentFieldExpression = _fieldExpressionBuffer.Trim();
            _fieldExpressionBuffer = "";

            if (string.IsNullOrEmpty(currentFieldExpression))
            {
                return;
            }

            var name = ParseName(currentFieldExpression, out var isOptional);
            var rule = _symbolCollection.GetOrAdd(name, _ => new Symbol {Name = name});

            Expression.Enqueue(new SymbolSequence
            {
                Reference = rule,
                IsOptional = isOptional
            });
        }

        private string ParseName(string expression, out bool isOptional)
        {
            isOptional = false;
            if (expression.StartsWith("[") &&
                expression.EndsWith("]"))
            {
                expression = expression.Substring(1, expression.Length - 2);
                isOptional = true;
            }

            return expression;
        }
    }

    internal class RuleParser
    {
        internal static Symbol Parse(Queue<char> buffer, ref SymbolCollection symbolCollection)
        {
            var symbolName = SymbolNameParser.Parse(buffer);

            var symbol = symbolCollection.GetOrAdd(symbolName, _ => new Symbol
            {
                Name = symbolName
            });

            var expression = ExpressionParser.Parse(buffer, symbolCollection);

            symbol.Expression = expression;

            return symbol;
        }
    }

    internal class BNFParser
    {
        internal Method Parse(string bnf)
        {
            var chars = new Queue<char>(bnf);

            return MethodParser.Parse(chars);
        }
    }

    internal class ApiKeyMessageMap
    {
        public string Name { get; internal set; }
        public int Key { get; internal set; }
    }

    internal class Message
    {
        public Message(int key, string name)
        {
            Key = key;
            Name = name;
        }

        public int Key { get; }
        public string Name { get; }

        private readonly Dictionary<int, Method> _requests = new Dictionary<int, Method>();
        public IReadOnlyDictionary<int, Method> Requests => _requests;

        internal void Add(int version, Method method)
        {
            _requests.Add(version, method);
        }

    }

    internal enum MethodType
    {
        Request,
        Response
    }


    internal class Method : Symbol
    {
        public int Version { get; set; }
        internal MethodType Type { get; set; }
        public List<Symbol> Fields { get; set; } = new List<Symbol>();
    }

    internal class Symbol
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Queue<SymbolSequence> Expression { get; set; } = new Queue<SymbolSequence>();
    }

    internal class SymbolSequence
    {
        public Symbol Reference { get; set; }
        public bool IsOptional { get; set; }
    }

    internal class SymbolCollection : ConcurrentDictionary<string, Symbol>
    {
    }

    internal class MethodSymbol
    {
        public string Name { get; set; }
        public int Version { get; set; }
        internal MethodType Type { get; set; }

    }
}