#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The transaction timeout is larger than the maximum value allowed by the broker (as configured by transaction.max.timeout.ms).</para>
    /// </summary>
    public class InvalidTransactionTimeoutException : Exception
    {
        public InvalidTransactionTimeoutException()
        {
        }

        public InvalidTransactionTimeoutException(string message) : base(message)
        {
        }

        public const int ErrorCode = 50;
        public int Code => ErrorCode;
    }
}
