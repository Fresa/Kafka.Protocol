using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using Kafka.Protocol.Generator.BackusNaurForm.Parsers;
using Kafka.Protocol.Generator.Definitions;
using Kafka.Protocol.Generator.Definitions.Messages;
using Kafka.Protocol.Generator.Definitions.Parsers;
using Kafka.Protocol.Generator.Extensions;
using Field = Kafka.Protocol.Generator.Definitions.Field;

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

            RequestHeader = ParseRequestHeader();
            ResponseHeader = ParseResponseHeader();

            //MessageEnvelope = ParseRequestAndResponseStructure();
        }

        public IDictionary<string, PrimitiveType> PrimitiveTypes { get; set; }

        public IDictionary<int, ErrorCode> ErrorCodes { get; }

        public IDictionary<int, Message> Messages { get; }

        public Header RequestHeader { get; }

        public Header ResponseHeader { get; }

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

            var header = HeaderParser.Parse(specification, PrimitiveTypes.Values);
        
            SetDescriptions(header.Fields, descriptionTable);

            return header;
        }
        
        private static void SetDescriptions(List<Field> fields, List<FieldDescription> fieldDescriptions)
        {
            foreach (var field in fields)
            {
                field.Description = fieldDescriptions
                    .FirstOrDefault(
                        description =>
                            description.Field == field.Name)?.Description;
            }
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