using Kafka.Protocol.Generator.Definitions.FieldExpression;

namespace Kafka.Protocol.Generator.Definitions
{
    internal class Field
    {
        public Field(string name, PostFixFieldExpression postFixFieldExpression)
        {
            Name = name;
            PostFixFieldExpression = postFixFieldExpression;
        }

        public string Name { get; }
        public string Description { get; set; }
        public PostFixFieldExpression PostFixFieldExpression { get; }
    }
}