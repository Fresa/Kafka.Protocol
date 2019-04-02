using System.Collections.Generic;

namespace Kafka.Protocol.Generator.Definitions
{
    public class MessageEnvelope
    {
        internal MessageEnvelope(
            string name, 
            List<Field> fields)
        {
            Name = name;
            Fields = fields;
        }

        public string Name { get; }
        public List<Field> Fields { get; }
    }
}