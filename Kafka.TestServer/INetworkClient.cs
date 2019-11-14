﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kafka.TestServer
{
    public interface INetworkClient : IAsyncDisposable
    {
        ValueTask<int> SendAsync(
            ReadOnlyMemory<byte> buffer,
            CancellationToken cancellationToken = default);

        ValueTask<int> ReceiveAsync(
            Memory<byte> buffer,
            CancellationToken cancellationToken = default);
    }
}