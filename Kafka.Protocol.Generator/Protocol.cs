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
}