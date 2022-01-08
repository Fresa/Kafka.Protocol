using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol.Records
{
    public class CompactNullableRecordBatch : BaseRecordBatch
    {
        internal static CompactNullableRecordBatch Default => new CompactNullableRecordBatch();

        public static ValueTask<CompactNullableRecordBatch> FromReaderAsync(
            PipeReader reader,
            CancellationToken cancellationToken = default) =>
            FromReaderAsync(new CompactNullableRecordBatch(), reader,
                true, cancellationToken);

        public new NullableArray<Record> Records
        {
            get => base.Records;
            set => base.Records = value;
        }

        protected override bool IsCompact => true;

        public static implicit operator RecordBatch?(CompactNullableRecordBatch recordBatch) =>
            recordBatch.Records.Value == null
                ? (RecordBatch?)null
                : new RecordBatch()
                {
                    Attributes = recordBatch.Attributes,

                };

        public static implicit operator CompactNullableRecordBatch(RecordBatch? recordBatch) =>
            recordBatch == null
                ? Default
                : new CompactNullableRecordBatch()
                {
                    Attributes = recordBatch.Attributes,

                };
    }
}