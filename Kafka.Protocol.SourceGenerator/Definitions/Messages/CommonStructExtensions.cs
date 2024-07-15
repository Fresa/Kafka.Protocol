namespace Kafka.Protocol.SourceGenerator.Definitions.Messages
{
    internal static class CommonStructExtensions
    {
        public static IEnumerable<Field> GetTaggedFields(this CommonStruct commonStruct) =>
            commonStruct.Fields
                .Where(childField => childField.Tag.HasValue)
                .OrderBy(childField => childField.Tag);
    }
}