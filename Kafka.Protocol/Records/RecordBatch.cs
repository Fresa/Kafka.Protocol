using System;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol.Records
{
    public class RecordBatch : BaseRecordBatch
    {
        internal static RecordBatch Default => new RecordBatch();

        public RecordBatch()
        {
            Records = Array<Record>.Default;
        }

        public static ValueTask<RecordBatch> FromReaderAsync(
            PipeReader reader,
            bool asCompact,
            CancellationToken cancellationToken = default) =>
            FromReaderAsync(new RecordBatch(), reader,
                asCompact, cancellationToken);

        public new Array<Record> Records
        {
            get => base.Records.Value!;
            set => base.Records = value;
        }

        [Flags]
        public enum CompressionType : ushort
        {
            None = 0,
            Gzip = 1,
            Snappy = 2,
            Lz4 = 4,
            Zstd = 8
        }

        [Flags]
        public enum Timestamp : byte
        {
            CreateTime = 0,
            LogAppendTime = 1
        }
    }
}