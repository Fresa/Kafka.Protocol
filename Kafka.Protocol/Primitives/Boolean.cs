﻿using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Kafka.Protocol
{
    public partial struct Boolean
    {
        internal int GetSize(bool asCompact) => 1;

        internal ValueTask WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken = default) =>
            writer.WriteAsLittleEndianAsync(BitConverter.GetBytes(Value), cancellationToken);

        internal static async ValueTask<Boolean> FromReaderAsync(
            PipeReader reader,
            bool _,
            CancellationToken cancellationToken = default) =>
            BitConverter.ToBoolean(
                await reader.ReadAsLittleEndianAsync(1, cancellationToken)
                    .ConfigureAwait(false),
                0);
    }
}