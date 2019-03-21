using System.Collections.Generic;
using Kafka.Protocol.Generator.Definitions.FieldExpression;

namespace Kafka.Protocol.Generator.Definitions
{
    public class MessageEnvelope
    {
        internal MessageEnvelope(
            string name, 
            PostFixFieldExpression postFixFieldExpression, 
            List<Field> fields)
        {
            Name = name;
            PostFixFieldExpression = postFixFieldExpression;
            Fields = fields;
        }

        public string Name { get; }
        public PostFixFieldExpression PostFixFieldExpression { get; }
        public List<Field> Fields { get; }
    }
}