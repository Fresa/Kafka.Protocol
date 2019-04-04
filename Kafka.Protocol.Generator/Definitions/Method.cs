using System.Collections.Generic;
using Kafka.Protocol.Generator.BackusNaurForm;
using Kafka.Protocol.Generator.Definitions.FieldExpression;
using Kafka.Protocol.Generator.Definitions.Messages;

namespace Kafka.Protocol.Generator.Definitions
{
    public class Method
    {
        public string Name { get; set; }
        public int Version { get; set; }
        internal MethodType Type { get; set; }

        public List<Field> Fields { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}