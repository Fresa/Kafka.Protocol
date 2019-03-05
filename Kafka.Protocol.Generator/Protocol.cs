using System;
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

        private IDictionary<int, Request> ParseRequestsForMessage(string name)
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

    internal class BNFParser
    {
        private const string DefinedAs = "=>";

        internal Request Parse(string bnf)
        {
            var expressions = new Queue<string>();
            var fields = new Dictionary<string, Field>();

            var buffer = "";
            Field currentField = null;
            Request message = null;

            var handler = (Action<char>)HandleName;

            var chars = new Queue<char>(bnf);
            while (chars.Any())
            {
                var c = chars.Dequeue();
                if (c == '=' && chars.Peek() == '>')
                {
                    chars.Dequeue();
                    HandleEndOfFieldName();
                    continue;
                }

                if (c == '\n')
                {
                    HandleEndOfField();
                    continue;
                }

                handler(c);
            }

            HandleEndOfField();

            message.Fields = fields.Values.ToList();
            return message;

            void HandleName(char c) => buffer += c;

            void HandleFields(char c)
            {
                if (c == ' ')
                {
                    expressions.Enqueue(buffer);
                    buffer = "";
                    return;
                }

                buffer += c;
            }

            void HandleEndOfField()
            {
                expressions.Enqueue(buffer);
                buffer = "";


                while (expressions.Any())
                {
                    var expression = expressions.Dequeue().Trim();
                    if (string.IsNullOrEmpty(expression))
                    {
                        continue;
                    }

                    var isOptional = false;
                    if (expression.StartsWith("[") &&
                        expression.EndsWith("]"))
                    {
                        expression = expression.Substring(1, expression.Length - 2);
                        isOptional = true;
                    }

                    if (fields.TryGetValue(expression, out var referencedField) == false)
                    {
                        referencedField = new Field
                        {
                            Name = expression,
                        };
                        fields.Add(referencedField.Name, referencedField);
                    }

                    var expressionQueue = message.Expressions;
                    if (currentField != null)
                    {
                        expressionQueue = currentField.Expressions;
                    }

                    expressionQueue.Enqueue(new Expression
                    {
                        FieldReference = referencedField,
                        IsOptional = isOptional
                    });
                }

                currentField = currentField ?? new Field();

                handler = HandleName;
            }

            void HandleEndOfFieldName()
            {
                var fieldName = buffer.Trim();
                buffer = "";
                handler = HandleFields;

                if (message == null)
                {
                    message = new Request();
                    var parts = fieldName.Split(' ');
                    message.Name = parts[0];
                    message.Version = int.Parse(parts.Last().Replace(")", ""));
                    return;
                }

                fields.TryGetValue(fieldName, out currentField);
            }
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

        private readonly Dictionary<int, Request> _requests = new Dictionary<int, Request>();
        public IReadOnlyDictionary<int, Request> Requests => _requests;

        internal void Add(int version, Request request)
        {
            _requests.Add(version, request);
        }

    }

    internal class Request : Field
    {
        public int Version { get; set; }
        public List<Field> Fields { get; set; } = new List<Field>();
    }

    internal class Field
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Queue<Expression> Expressions { get; set; } = new Queue<Expression>();
    }

    internal class Expression
    {
        public Field FieldReference { get; set; }
        public bool IsOptional { get; set; }
    }

    internal class Response
    {

    }


}