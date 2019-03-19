using System.Collections.Generic;
using Kafka.Protocol.Generator.BackusNaurForm;
using Kafka.Protocol.Generator.Definitions.FieldExpression;

namespace Kafka.Protocol.Generator.Definitions
{
    public class Method
    {
        internal Method(
            MethodMetaData metaData,
            PostFixFieldExpression postFixFieldExpression, 
            List<Field> fields)
        {
            Name = metaData.Name;
            Version = metaData.Version;
            Type = metaData.Type;
            Fields = fields;
            PostFixFieldExpression = postFixFieldExpression;
        }

        public int Version { get; }
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