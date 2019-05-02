using System.Collections.Generic;

namespace Kafka.Protocol.Generator.Definitions.Messages
{
    public class Field
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Versions { get; set; }

        public string NullableVersions { get; set; }

        public bool Ignorable { get; set; }

        public string Default { get; set; }

        public string About { get; set; }

        public bool MapKey { get; set; }

        public List<Field> Fields { get; set; }
    }
}