namespace Kafka.Protocol.Generator.Definitions
{
    public class Field
    {
        public Field(FieldReference fieldReference, Type type)
        {
            Name = fieldReference.Type.Name;
            IsRepeatable = fieldReference.IsRepeatable;
            Type = type;
        }

        public string Name { get; }
        public Type Type { get; }
        public bool IsRepeatable { get; }
        public string Description { get; set; }
    }
}