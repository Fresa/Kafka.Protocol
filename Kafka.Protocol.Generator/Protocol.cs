using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using Kafka.Protocol.Generator.BackusNaurForm.Parsers;
using Kafka.Protocol.Generator.Definitions;
using Kafka.Protocol.Generator.Definitions.Parsers;
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

            ErrorCodes = ParseErrorCodes();
            PrimitiveTypes = ParsePrimitiveTypes();
            Messages = ParseMessages();
            RequestHeader = ParseRequestHeader();
            ResponseHeader = ParseResponseHeader();
        }

        internal IDictionary<string, PrimitiveType> PrimitiveTypes { get; set; }

        internal IDictionary<int, ErrorCode> ErrorCodes { get; }

        internal IDictionary<int, Message> Messages { get; }

        internal Header RequestHeader { get; }

        internal Header ResponseHeader { get; }

        private const string ProtocolRequestHeaderXPath = "//*/pre[starts-with(text(),'Request Header')]";

        private Header ParseRequestHeader()
        {
            var headerNode = _definition
                .DocumentNode
                .SelectFirst(ProtocolRequestHeaderXPath);

            return ParseHeader(headerNode);
        }

        private const string ProtocolResponseHeaderXPath = "//*/pre[starts-with(text(),'Response Header')]";

        private Header ParseResponseHeader()
        {
            var headerNode = _definition
                .DocumentNode
                .SelectFirst(ProtocolResponseHeaderXPath);

            return ParseHeader(headerNode);
        }

        private Header ParseHeader(HtmlNode headerNode)
        {
            var headerDefinition = System.Net.WebUtility.HtmlDecode(
                headerNode
                    .InnerText);

            var descriptionTable = headerNode
                .GetFirstSiblingNamed("table")
                .ParseTableNodeTo<FieldDescription>()
                .ToList();

            var specification = BackusNaurParser.Parse(
                new Buffer<char>(
                    headerDefinition
                        .ToCharArray()));

            var header = HeaderParser.Parse(specification);
            ValidateHeader(header);

            SetDescriptions(header.Fields, descriptionTable);

            return header;
        }

        private void ValidateHeader(Header header)
        {
            var fieldReferences =
                header
                    .Fields
                    .SelectMany(
                        field => field
                            .FieldReferences)
                    .ToList();
            fieldReferences.AddRange(header.FieldReferences);

            foreach (var fieldReference in fieldReferences)
            {
                ValidateTypeReference(fieldReference.Type, header);
            }
        }

        private void ValidateTypeReference(TypeReference typeReference, Header header)
        {
            if (typeReference.IsGeneric)
            {
                ValidateTypeReference(typeReference.GenericArgument, header);
            }

            if (PrimitiveTypes.ContainsKey(
                typeReference.Name))
            {
                return;
            }

            if (header.Fields.Any(
                field =>
                    field.Name == typeReference.Name))
            {
                return;
            }

            throw new InvalidOperationException(
                $"'{header}' has a reference to type '{typeReference}' which does not appear within the parsed symbols nor the primitive types");
        }

        private const string ProtocolApiKeysXPath = "//*[contains(@id,'protocol_api_keys')]/..";

        private IDictionary<int, Message> ParseMessages()
        {
            var apiKeyMessageMaps = _definition
                .DocumentNode
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

        private static string GetProtocolRequestMethodXPathFor(string methodName) =>
            $"//*/pre[starts-with(text(),'{methodName} Request')]";

        private List<Method> ParseRequestsForMessage(string name)
        {
            return _definition
                .DocumentNode
                .SelectNodes(GetProtocolRequestMethodXPathFor(name))
                .Select(ParseMethodDefinitionNode)
                .ToList();
        }

        private static string GetProtocolResponseMethodXPathFor(string methodName) =>
            $"//*/pre[starts-with(text(),'{methodName} Response')]";

        private IEnumerable<Method> ParseResponsesForMessage(string name)
        {
            return _definition
                .DocumentNode
                .SelectNodes(GetProtocolResponseMethodXPathFor(name))
                .Select(ParseMethodDefinitionNode);
        }

        private Method ParseMethodDefinitionNode(HtmlNode definitionNode)
        {
            var definition = System.Net.WebUtility.HtmlDecode(
                definitionNode
                    .InnerText);

            var descriptionTable = definitionNode
                .GetFirstSiblingNamed("table")
                .ParseTableNodeTo<FieldDescription>()
                .ToList();

            var specification = BackusNaurParser.Parse(
                new Buffer<char>(
                    definition
                        .ToCharArray()));

            var method = MethodParser.Parse(specification);
            ValidateMethod(method);

            SetDescriptions(method.Fields, descriptionTable);

            return method;
        }

        private void SetDescriptions(List<Field> fields, List<FieldDescription> fieldDescriptions)
        {
            foreach (var field in fields)
            {
                field.Description = fieldDescriptions
                    .FirstOrDefault(
                        description =>
                            description.Field == field.Name)?.Description;
            }
        }

        private void ValidateMethod(Method method)
        {
            var fieldReferences =
                method
                    .Fields
                    .SelectMany(
                        field => field
                            .FieldReferences)
                    .ToList();
            fieldReferences.AddRange(method.FieldReferences);

            foreach (var fieldReference in fieldReferences)
            {
                ValidateTypeReference(fieldReference.Type, method);
            }
        }

        private void ValidateTypeReference(TypeReference typeReference, Method method)
        {
            if (typeReference.IsGeneric)
            {
                ValidateTypeReference(typeReference.GenericArgument, method);
            }

            if (PrimitiveTypes.ContainsKey(
                typeReference.Name))
            {
                return;
            }

            if (method.Fields.Any(
                field =>
                    field.Name == typeReference.Name))
            {
                return;
            }

            throw new InvalidOperationException(
                $"Method '{method}' has a reference to type '{typeReference}' which does not appear within the parsed symbols nor the primitive types");
        }

        private const string ProtocolErrorCodesXPath = "//*[contains(@id,'protocol_error_codes')]/..";

        private IDictionary<int, ErrorCode> ParseErrorCodes()
        {
            return _definition
                .DocumentNode
                .SelectFirst(ProtocolErrorCodesXPath)
                .GetFirstSiblingNamed("table")
                .ParseTableNodeTo<ErrorCode>()
                .ToDictionary(
                    errorCode => errorCode.Code);
        }

        private const string PrimitiveTypesXPath = "//*[contains(@id,'protocol_types')]/..";

        private IDictionary<string, PrimitiveType> ParsePrimitiveTypes()
        {
            return _definition
                .DocumentNode
                .SelectFirst(PrimitiveTypesXPath)
                .GetFirstSiblingNamed("table")
                .ParseTableNodeTo<PrimitiveType>()
                .ToDictionary(
                    type => type.Type);
        }
    }
}