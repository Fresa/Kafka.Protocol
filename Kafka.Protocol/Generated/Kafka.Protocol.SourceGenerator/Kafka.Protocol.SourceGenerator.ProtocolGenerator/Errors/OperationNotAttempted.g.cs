#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The broker did not attempt to execute this operation. This may happen for batched RPCs where some operations in the batch failed, causing the broker to respond without trying the rest.</para>
    /// </summary>
    public class OperationNotAttemptedException : Exception
    {
        public OperationNotAttemptedException()
        {
        }

        public OperationNotAttemptedException(string message) : base(message)
        {
        }

        public const int ErrorCode = 55;
        public int Code => ErrorCode;
    }
}
