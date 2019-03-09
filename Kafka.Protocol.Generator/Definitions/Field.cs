using System.Collections.Generic;

namespace Kafka.Protocol.Generator.Definitions
{
    internal class Field
    {
        public Field(string name, List<FieldReference> fieldReferences)
        {
            Name = name;
            FieldReferences = fieldReferences;
        }

        public string Name { get; }
        public string Description { get; set; }
        public List<FieldReference> FieldReferences { get; }
    }
}