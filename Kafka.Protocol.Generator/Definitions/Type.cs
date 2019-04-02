using System.Collections.Generic;

namespace Kafka.Protocol.Generator.Definitions
{
    public class Type
    {
        public string Name { get; set; }

        public List<Field> Fields { get; set; } = new List<Field>();
    }
}