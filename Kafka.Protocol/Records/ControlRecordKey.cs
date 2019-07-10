namespace Kafka.Protocol.Records
{
    public class ControlRecordKey : ISerialize
    {
        private Int16 _version = Int16.Default;
        public Int16 Version
        {
            get => _version;
            set
            {
                if (value != Int16.From(0))
                {
                    throw new UnsupportedVersionException($"Version '{value}' is not supported. Supported version is 0");
                }

                _version = value;
            }
        }

        public Int16 Type { get; private set;} = Int16.Default;

        public bool IsAbortMarker
        {
            get => Type == Int16.From(0);
            set => Type = Int16.From(value ? (short)0 : (short)1);
        }

        public bool IsCommit
        {
            get => Type == Int16.From(1);
            set => Type = Int16.From(value ? (short)1 : (short)0);
        }

        public void ReadFrom(IKafkaReader reader)
        {
            Version = Int16.From(reader.ReadInt16());
            Type = Int16.From(reader.ReadInt16());
        }

        public void WriteTo(IKafkaWriter writer)
        {
            writer.WriteInt16(Version.Value);
            writer.WriteInt16(Type.Value);
        }
    }
}