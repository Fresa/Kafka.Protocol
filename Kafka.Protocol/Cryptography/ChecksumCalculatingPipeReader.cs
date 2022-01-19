using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.Protocol.Cryptography
{
    internal sealed class ChecksumCalculatingPipeReader : PipeReader
    {
        private readonly PipeReader _reader;
        private ReadResult _result;
        internal uint Checksum { get; private set; }
        
        public ChecksumCalculatingPipeReader(PipeReader reader)
        {
            _reader = reader;
        }

        public override bool TryRead(out ReadResult result) => _reader.TryRead(out result);

        public override async ValueTask<ReadResult> ReadAsync(
            CancellationToken cancellationToken = new CancellationToken())
        {
            _result = await _reader.ReadAsync(cancellationToken)
                .ConfigureAwait(false);
            return _result;
        }

        public override void AdvanceTo(SequencePosition consumed)
        {
            var data = _result.Buffer.Slice(0, consumed);
            Checksum = Crc32C.Append(Checksum, data.ToArray());
            _reader.AdvanceTo(consumed);
        }

        public override void AdvanceTo(SequencePosition consumed, SequencePosition examined)
        {
            var data = _result.Buffer.Slice(0, consumed);
            Checksum = Crc32C.Append(Checksum, data.ToArray());
            _reader.AdvanceTo(consumed, examined);
        }

        public override void CancelPendingRead() => _reader.CancelPendingRead();

        public override void Complete(Exception? exception = null) => _reader.Complete(exception);

        public override void OnWriterCompleted(Action<Exception, object> callback, object state) => _reader.OnWriterCompleted(callback, state);
    }
}