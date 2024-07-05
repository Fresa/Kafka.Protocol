#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The producer attempted a transactional operation in an invalid state.</para>
    /// </summary>
    public class InvalidTxnStateException : Exception
    {
        public InvalidTxnStateException()
        {
        }

        public InvalidTxnStateException(string message) : base(message)
        {
        }

        public const int ErrorCode = 48;
        public int Code => ErrorCode;
    }
}
