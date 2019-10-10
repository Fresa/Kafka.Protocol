using System.Collections.Generic;

namespace Kafka.Protocol.Generator.Helpers.Definitions.Messages
{
    public class CommonStruct
    {
        public string Name { get; set; }

        public string Versions { get; set; }

        public List<Field> Fields { get; set; }
    }
}