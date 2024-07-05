#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>There are unstable offsets that need to be cleared.</para>
    /// </summary>
    public class UnstableOffsetCommitException : Exception
    {
        public UnstableOffsetCommitException()
        {
        }

        public UnstableOffsetCommitException(string message) : base(message)
        {
        }

        public const int ErrorCode = 88;
        public int Code => ErrorCode;
    }
}
