#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The leader high watermark has not caught up from a recent leader election so the offsets cannot be guaranteed to be monotonically increasing.</para>
    /// </summary>
    public class OffsetNotAvailableException : Exception
    {
        public OffsetNotAvailableException()
        {
        }

        public OffsetNotAvailableException(string message) : base(message)
        {
        }

        public const int ErrorCode = 78;
        public int Code => ErrorCode;
    }
}
