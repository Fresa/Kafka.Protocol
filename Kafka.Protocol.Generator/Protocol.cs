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
            ErrorCodes = ParseErrorCodes(definition.DocumentNode);
            PrimitiveTypes = ParsePrimitiveTypes();
            Messages = ParseMessages(definition.DocumentNode);
        }

        internal IDictionary<string, PrimitiveType> PrimitiveTypes { get; set; }

        internal IDictionary<int, ErrorCode> ErrorCodes { get; }

        internal IDictionary<int, Message> Messages { get; }

        private const string ProtocolApiKeysXPath = "//*[contains(@id,'protocol_api_keys')]/..";

        private IDictionary<int, Message> ParseMessages(HtmlNode node)
        {
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

        private static string GetProtocolRequestMethodXPathFor(string methodName) =>
            $"//*/pre[starts-with(text(),'{methodName} Request')]";

        private List<Method> ParseRequestsForMessage(string name)
        {
            return _definition
                .DocumentNode
                .SelectNodes(GetProtocolRequestMethodXPathFor(name))
                .Select(ParseDefinitionNode)
                .ToList();
        }

        private static string GetProtocolResponseMethodXPathFor(string methodName) =>
            $"//*/pre[starts-with(text(),'{methodName} Response')]";

        private IEnumerable<Method> ParseResponsesForMessage(string name)
        {
            return _definition
                .DocumentNode
                .SelectNodes(GetProtocolResponseMethodXPathFor(name))
                .Select(ParseDefinitionNode);
        }

        private Method ParseDefinitionNode(HtmlNode definitionNode)
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

            foreach (var field in method.Fields)
            {
                field.Description = descriptionTable
                    .FirstOrDefault(
                        description =>
                            description.Field == field.Name)?.Description;
            }

            return method;
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

        private static IDictionary<int, ErrorCode> ParseErrorCodes(HtmlNode node)
        {
            return node
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