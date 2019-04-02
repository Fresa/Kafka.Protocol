using System.Collections.Generic;
using Kafka.Protocol.Generator.BackusNaurForm;
using Kafka.Protocol.Generator.Definitions.FieldExpression;

namespace Kafka.Protocol.Generator.Definitions
{
    public class Method
    {
        public string Name { get; set; }
        public int Version { get; set; }
        internal MethodType Type { get; }

        public List<Field> Fields { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}