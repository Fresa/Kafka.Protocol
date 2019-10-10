using System.Collections.Generic;

namespace Kafka.Protocol.Generator.Helpers.Definitions
{
    public class Header
    {
        internal Header(
            HeaderMetaData metaData,
            List<Field> fields)
        {
            Name = metaData.Name;
            Type = metaData.Type;
            Fields = fields;
        }

        internal MethodType Type { get; }
        public List<Field> Fields { get; }
        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}