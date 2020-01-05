using System;

namespace Kafka.Protocol
{
    public interface IStreamLengthReport : IDisposable
    {
        int BytesRead { get; }
    }
}