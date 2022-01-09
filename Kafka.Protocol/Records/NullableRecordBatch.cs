using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol.Records
{
    public class NullableRecordBatch : BaseRecordBatch
    {
        internal static NullableRecordBatch Default => new NullableRecordBatch();

        internal static ValueTask<NullableRecordBatch> FromReaderAsync(
            PipeReader reader,
            bool asCompact,
            CancellationToken cancellationToken = default) =>
            FromReaderAsync(new NullableRecordBatch(), reader,
                asCompact, cancellationToken);

        public new NullableArray<Record> Records
        {
            get => base.Records;
            set => base.Records = value;
        }

        public static implicit operator RecordBatch?(NullableRecordBatch recordBatch) =>
            recordBatch.Records.Value == null
                ? (RecordBatch?)null
                : new RecordBatch()
                {
                    Attributes = recordBatch.Attributes,

                };

        public static implicit operator NullableRecordBatch(RecordBatch? recordBatch) =>
            recordBatch == null
                ? Default
                : new NullableRecordBatch()
                {
                    Attributes = recordBatch.Attributes,

                };
    }
}