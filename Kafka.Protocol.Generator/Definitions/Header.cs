using System.Collections.Generic;

namespace Kafka.Protocol.Generator.Definitions
{
    internal class Header
    {
        internal Header(
            HeaderMetaData metaData,
            List<FieldReference> fieldReferences,
            List<Field> fields)
        {
            Name = metaData.Name;
            Type = metaData.Type;
            Fields = fields;
            FieldReferences = fieldReferences;
        }

        internal MethodType Type { get; }
        public List<Field> Fields { get; }
        public string Name { get; }
        public List<FieldReference> FieldReferences { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}