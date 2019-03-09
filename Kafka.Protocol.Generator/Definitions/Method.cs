using System.Collections.Generic;
using Kafka.Protocol.Generator.BackusNaurForm;

namespace Kafka.Protocol.Generator.Definitions
{
    internal class Method
    {
        internal Method(
            MethodMetaData metaData,
            List<FieldReference> fieldReferences, 
            List<Field> fields)
        {
            Name = metaData.Name;
            Version = metaData.Version;
            Type = metaData.Type;
            Fields = fields;
            FieldReferences = fieldReferences;
        }

        public int Version { get; }
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