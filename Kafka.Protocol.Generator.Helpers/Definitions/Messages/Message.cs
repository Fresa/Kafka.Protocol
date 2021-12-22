using System.Collections.Generic;

namespace Kafka.Protocol.Generator.Helpers.Definitions.Messages
{
    public class Message
    {
        public int ApiKey { get; set; } = default!;

        public string Type { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string ValidVersions { get; set; } = default!;

        public string FlexibleVersions { get; set; } = default!;

        public List<Field> Fields { get; set; } = new();

        public List<CommonStruct>? CommonStructs { get; set; }
    }
}