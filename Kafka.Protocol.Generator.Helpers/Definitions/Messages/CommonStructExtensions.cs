using System.Collections.Generic;
using System.Linq;

namespace Kafka.Protocol.Generator.Helpers.Definitions.Messages
{
    public static class CommonStructExtensions
    {
        public static IEnumerable<Field> GetTaggedFields(this CommonStruct commonStruct) =>
            commonStruct.Fields
                .Where(childField => childField.Tag.HasValue)
                .OrderBy(childField => childField.Tag);

        public static IEnumerable<Field> GetNonTaggedFields(this CommonStruct commonStruct) =>
            commonStruct.Fields
                .Where(childField => !childField.Tag.HasValue);
    }
}