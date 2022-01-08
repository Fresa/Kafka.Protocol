using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol.Records
{
    public class NullableRecordBatch : BaseRecordBatch
    {
        internal static NullableRecordBatch Default => new NullableRecordBatch();

        public static ValueTask<NullableRecordBatch> FromReaderAsync(
            PipeReader reader,
            CancellationToken cancellationToken = default) =>
            FromReaderAsync(new NullableRecordBatch(), reader,
                false, cancellationToken);

        public new NullableArray<Record> Records
        {
            get => base.Records;
            set => base.Records = value;
        }

        protected override bool IsCompact => false;

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