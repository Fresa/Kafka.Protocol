using System.Collections.Generic;

namespace Kafka.Protocol.Generator.Helpers.Definitions.Messages
{
    public class Message
    {
        public int ApiKey { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string ValidVersions { get; set; }

        public List<Field> Fields { get; set; }

        public List<CommonStruct> CommonStructs { get; set; }
    }
}