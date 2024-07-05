#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The broker received a duplicate sequence number.</para>
    /// </summary>
    public class DuplicateSequenceNumberException : Exception
    {
        public DuplicateSequenceNumberException()
        {
        }

        public DuplicateSequenceNumberException(string message) : base(message)
        {
        }

        public const int ErrorCode = 46;
        public int Code => ErrorCode;
    }
}
