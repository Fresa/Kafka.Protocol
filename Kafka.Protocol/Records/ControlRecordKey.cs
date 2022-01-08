using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

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
                    throw new UnsupportedVersionException(
                        $"Version '{value}' is not supported. Supported version is 0");
                }

                _version = value;
            }
        }

        private Int16 _type = Int16.Default;

        public bool IsAbortMarker
        {
            get => _type == Int16.From(0);
            set => _type = Int16.From(value ? (short) 0 : (short) 1);
        }

        public bool IsCommit
        {
            get => _type == Int16.From(1);
            set => _type = Int16.From(value ? (short) 1 : (short) 0);
        }

        public async ValueTask ReadFromAsync(
            PipeReader reader,
            bool asCompact,
            CancellationToken cancellationToken = default)
        {
            Version = await Int16.FromReaderAsync(reader, asCompact, cancellationToken)
                .ConfigureAwait(false);
            _type = await Int16.FromReaderAsync(reader, asCompact, cancellationToken)
                .ConfigureAwait(false);
        }

        public async ValueTask WriteToAsync(
            Stream writer,
            bool asCompact,
            CancellationToken cancellationToken = default)
        {
            await Version.WriteToAsync(writer, asCompact, cancellationToken)
                .ConfigureAwait(false);
            await _type.WriteToAsync(writer, asCompact, cancellationToken)
                .ConfigureAwait(false);
        }

        public int GetSize(bool asCompact) =>
            Version.GetSize(asCompact) +
            _type.GetSize(asCompact);
    }
}