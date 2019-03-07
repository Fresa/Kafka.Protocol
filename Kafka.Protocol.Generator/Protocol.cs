using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using HtmlAgilityPack;
using Kafka.Protocol.Generator.BackusNaurForm;
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
                var methods = ParseRequestsForMessage(apiKeyMessageMap.Name);
                methods.AddRange(ParseResponsesForMessage(apiKeyMessageMap.Name));

                var message = new Message(
                    apiKeyMessageMap.Key,
                    apiKeyMessageMap.Name,
                    methods);

                messages.Add(apiKeyMessageMap.Key, message);
            }

            return messages;
        }

        private string GetProtocolRequestMethodXPathFor(string methodName) =>
            $"//*/pre[starts-with(text(),'{methodName} Request')]";

        private List<Method> ParseRequestsForMessage(string name)
        {
            var nodes = _definition
                .DocumentNode
                .SelectNodes(GetProtocolRequestMethodXPathFor(name));

            var methods = new List<Method>();
            foreach (var definitionNode in nodes)
            {
                var definition = System.Net.WebUtility.HtmlDecode(
                       definitionNode
                           .InnerText);

                var descriptionTable = definitionNode
                    .GetFirstSiblingNamed("table")
                    .ParseTableNodeTo<FieldDescription>()
                    .ToList();

                var method = MethodParser.Parse(
                    new Buffer<char>(
                        definition
                            .ToCharArray()));

                foreach (var symbol in method.Symbols)
                {
                    symbol.Description = descriptionTable
                        .FirstOrDefault(
                            description => 
                                description.Field == symbol.Name)?.Description;
                }

                methods.Add(method);
            }

            return methods;
        }

        private string GetProtocolResponseMethodXPathFor(string methodName) =>
            $"//*/pre[starts-with(text(),'{methodName} Response')]";

        private List<Method> ParseResponsesForMessage(string name)
        {
            var nodes = _definition
                .DocumentNode
                .SelectNodes(GetProtocolResponseMethodXPathFor(name));

            var methods = new List<Method>();
            foreach (var definitionNode in nodes)
            {
                var definition = System.Net.WebUtility.HtmlDecode(
                    definitionNode
                        .InnerText);

                var descriptionTable = definitionNode
                    .GetFirstSiblingNamed("table")
                    .ParseTableNodeTo<FieldDescription>()
                    .ToList();

                var method = MethodParser.Parse(
                    new Buffer<char>(
                        definition
                            .ToCharArray()));

                foreach (var symbol in method.Symbols)
                {
                    symbol.Description = descriptionTable
                        .FirstOrDefault(
                            description =>
                                description.Field == symbol.Name)?.Description;
                }

                methods.Add(method);
            }

            return methods;           
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
}