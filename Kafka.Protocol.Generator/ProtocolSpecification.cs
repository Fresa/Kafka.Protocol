using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using HtmlAgilityPack;
using Kafka.Protocol.Generator.BackusNaurForm.Parsers;
using Kafka.Protocol.Generator.Definitions;
using Kafka.Protocol.Generator.Definitions.FieldExpression;
using Kafka.Protocol.Generator.Definitions.Parsers;
using Kafka.Protocol.Generator.Extensions;

namespace Kafka.Protocol.Generator
{
    public class ProtocolSpecification
    {
        private readonly HtmlDocument _definition;

        public static ProtocolSpecification Load(HtmlDocument definition)
        {
            return new ProtocolSpecification(definition);
        }

        private ProtocolSpecification(HtmlDocument definition)
        {
            _definition = definition;

            ErrorCodes = ParseErrorCodes();
            PrimitiveTypes = ParsePrimitiveTypes();

            Messages = ParseMessages();
            RequestHeader = ParseRequestHeader();
            ResponseHeader = ParseResponseHeader();

            MessageEnvelope = ParseRequestAndResponseStructure();
        }

        public IDictionary<string, PrimitiveType> PrimitiveTypes { get; set; }

        public IDictionary<int, ErrorCode> ErrorCodes { get; }

        public IDictionary<int, Message> Messages { get; }

        public Header RequestHeader { get; }

        public Header ResponseHeader { get; }

        public MessageEnvelope MessageEnvelope { get; }

        private const string RequestOrResponseXPath = "//*/pre[starts-with(text(),'RequestOrResponse')]";

        private MessageEnvelope ParseRequestAndResponseStructure()
        {
            var requestOrResponseNode = _definition
                .DocumentNode
                .SelectFirst(RequestOrResponseXPath);

            var requestOrResponseDefinition = System.Net.WebUtility.HtmlDecode(
                requestOrResponseNode
                    .InnerText);

            var descriptionTable = requestOrResponseNode
                .GetFirstSiblingNamed("table")
                .ParseTableNodeTo<FieldDescription>()
                .ToList();

            // Known inconsistency in the documentation
            var messageSize = descriptionTable.FirstOrDefault(description => description.Field == "message_size");
            if (messageSize != null)
            {
                messageSize.Field = "Size";
            }

            var specification = BackusNaurParser.Parse(
                new Buffer<char>(
                    requestOrResponseDefinition
                        .ToCharArray()));

            var messageEnvelope = MessageEnvelopeParser.Parse(specification);

            // Known missing fields in the specification
            PrimitiveTypes.Add("RequestMessage", new PrimitiveType
            {
                Type = "RequestMessage",
                Description = "Request message"
            });
            PrimitiveTypes.Add("ResponseMessage", new PrimitiveType
            {
                Type = "ResponseMessage",
                Description = "Response message"
            });

            ValidateMessageEnvelope(messageEnvelope);

            SetDescriptions(messageEnvelope.Fields, descriptionTable);

            return messageEnvelope;
        }

        private void ValidateMessageEnvelope(MessageEnvelope messageEnvelope)
        {
            var fieldReferences =
                messageEnvelope
                    .Fields
                    .SelectMany(
                        field => field
                            .PostFixFieldExpression.ExpressionTokens)
                    .OfType<FieldReference>()
                    .ToList();
            fieldReferences.AddRange(
                messageEnvelope
                    .PostFixFieldExpression
                    .ExpressionTokens
                    .OfType<FieldReference>());

            foreach (var fieldReference in fieldReferences)
            {
                ValidateTypeReference(fieldReference.Type, messageEnvelope);
            }
        }

        private void ValidateTypeReference(TypeReference typeReference, MessageEnvelope messageEnvelope)
        {
            if (typeReference.IsGeneric)
            {
                ValidateTypeReference(typeReference.GenericArgument, messageEnvelope);
            }

            if (PrimitiveTypes.Keys.Contains(
                typeReference.Name, StringComparer.CurrentCultureIgnoreCase))
            {
                return;
            }

            if (messageEnvelope.Fields.Any(
                field =>
                    field.Name.Equals(typeReference.Name, StringComparison.CurrentCultureIgnoreCase)))
            {
                return;
            }

            throw new InvalidOperationException(
                $"'{messageEnvelope}' has a reference to type '{typeReference}' which does not appear within the parsed symbols nor the primitive types");
        }

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
                            .PostFixFieldExpression.ExpressionTokens)
                    .OfType<FieldReference>()
                    .ToList();
            fieldReferences.AddRange(
                header
                    .PostFixFieldExpression
                    .ExpressionTokens
                    .OfType<FieldReference>());

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
                            .PostFixFieldExpression.ExpressionTokens)
                    .OfType<FieldReference>()
                    .ToList();
            fieldReferences.AddRange(method
                .PostFixFieldExpression
                .ExpressionTokens
                .OfType<FieldReference>());

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