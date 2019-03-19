using System.Collections.Generic;
using Kafka.Protocol.Generator.Definitions.FieldExpression;

namespace Kafka.Protocol.Generator.Definitions
{
    public class Header
    {
        internal Header(
            HeaderMetaData metaData,
            PostFixFieldExpression postFixFieldExpression,
            List<Field> fields)
        {
            Name = metaData.Name;
            Type = metaData.Type;
            Fields = fields;
            PostFixFieldExpression = postFixFieldExpression;
        }

        internal MethodType Type { get; }
        public List<Field> Fields { get; }
        public string Name { get; }
        public PostFixFieldExpression PostFixFieldExpression { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}