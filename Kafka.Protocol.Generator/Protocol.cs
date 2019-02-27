using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using Kafka.Protocol.Generator.Extensions;

namespace Kafka.Protocol.Generator
{
    internal class Protocol
    {
        internal static Protocol Load(HtmlDocument definition)
        {
            return new Protocol(definition);
        }

        private Protocol(HtmlDocument definition)
        {
            ErrorCodes = ParseErrorCodes(definition.DocumentNode);
            Requests = ParseRequests(definition.DocumentNode);
        }

        internal IDictionary<int, ErrorCode> ErrorCodes { get; }

        internal IDictionary<int, Request> Requests { get; }

        private const string ProtocolApiKeysXPath = "//*[contains(@id,'protocol_api_keys')]/..";

        private static IDictionary<int, Request> ParseRequests(HtmlNode node)
        {
            return node
                .SelectFirst(ProtocolApiKeysXPath)
                .GetFirstSiblingNamed("table")
                .ParseTableNodeTo<Request>(cell => 
                    cell.FirstChild.InnerText)
                .ToDictionary(
                    request => request.Key);
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

    internal class Request
    {
        public string Name { get; internal set; }
        public int Key { get; internal set; }
    }
}