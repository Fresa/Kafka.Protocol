using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol.Records
{
    public class CompactRecordBatch : BaseRecordBatch
    {
        internal static CompactRecordBatch Default => new CompactRecordBatch();

        public CompactRecordBatch()
        {
            Records = Array<Record>.Default;
        }

        public static ValueTask<CompactRecordBatch> FromReaderAsync(
            PipeReader reader,
            CancellationToken cancellationToken = default) =>
            FromReaderAsync(new CompactRecordBatch(), reader,
                true, cancellationToken);

        public new Array<Record> Records
        {
            get => base.Records.Value!;
            set => base.Records = value;
        }

        protected override bool IsCompact => true;
    }
}