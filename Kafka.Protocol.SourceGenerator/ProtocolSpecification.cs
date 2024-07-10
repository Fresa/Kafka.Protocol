using HtmlAgilityPack;
using Kafka.Protocol.SourceGenerator.Definitions;
using Kafka.Protocol.SourceGenerator.Definitions.Messages;
using Kafka.Protocol.SourceGenerator.Extensions;

namespace Kafka.Protocol.SourceGenerator
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
            // The following types are not explicitly defined in the specification but is used within the protocol
            PrimitiveTypes.Add("NULLABLE_ARRAY", new PrimitiveType
            {
                Type = "NULLABLE_ARRAY",
                Description = "Represents a sequence of objects of a given type T. Type T can be either a primitive type (e.g. STRING) or a structure. First, the length N + 1 is given as an UNSIGNED_VARINT. Then N instances of type T follow. A null array is represented with a length of 0. In protocol documentation an array of T instances is referred to as [T]."
            });
            PrimitiveTypes.Add("MAP", new PrimitiveType
            {
                Type = "MAP",
                Description = "Represents a sequence of objects with a map key."
            });
            PrimitiveTypes.Add("NULLABLE_MAP", new PrimitiveType
            {
                Type = "NULLABLE_MAP",
                Description = "Represents a nullable sequence of objects with a map key."
            });
            
            // Compact types are still the same base types but with more efficient length compaction. They are used interchangeable when the message is a variable version
            PrimitiveTypes.Keys
                .Where(name => name.StartsWith("COMPACT_"))
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