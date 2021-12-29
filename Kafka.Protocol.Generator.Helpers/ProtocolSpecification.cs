using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using Kafka.Protocol.Generator.Helpers.Definitions;
using Kafka.Protocol.Generator.Helpers.Definitions.Messages;
using Kafka.Protocol.Generator.Helpers.Extensions;

namespace Kafka.Protocol.Generator.Helpers
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
            // UINT16 is missing from the documentation but found in the message specifications
            PrimitiveTypes.Add("UINT16", new PrimitiveType
            {
                Type = "UINT16", 
                Description = "Represents an integer between 0 and 2^16-1 inclusive. The values are encoded using four bytes in network byte order (big-endian)."
            });
            // UVARINT is missing from the documentation but found in the message specifications
            PrimitiveTypes.Add("UVARINT", new PrimitiveType
            {
                Type = "UVARINT",
                Description = "The UNSIGNED_VARINT type describes an unsigned variable length integer."
            });

            // Incorrect protocol definition: Array is never referenced as a primitive type within messages. [] is used.
            PrimitiveTypes.Remove("ARRAY");
            // Compact types are still the same base types but with more efficient length compaction. They are used interchangeable when the message is a variable version
            // Nullable types are handled as native nullable types
            PrimitiveTypes.Keys
                .Where(name => name.StartsWith("COMPACT_") ||
                               name.StartsWith("NULLABLE_"))
                .ToList()
                .ForEach(name => PrimitiveTypes.Remove(name));
            // Records is a complex type and is hand-rolled
            PrimitiveTypes.Remove("RECORDS");
        }

        public IDictionary<string, PrimitiveType> PrimitiveTypes { get; set; }

        public IDictionary<int, ErrorCode> ErrorCodes { get; }

        public IDictionary<int, Message> Messages { get; } = new Dictionary<int, Message>();
        
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