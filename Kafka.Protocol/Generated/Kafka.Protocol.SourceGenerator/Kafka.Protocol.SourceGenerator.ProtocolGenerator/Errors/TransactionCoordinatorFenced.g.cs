#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Indicates that the transaction coordinator sending a WriteTxnMarker is no longer the current coordinator for a given producer.</para>
    /// </summary>
    public class TransactionCoordinatorFencedException : Exception
    {
        public TransactionCoordinatorFencedException()
        {
        }

        public TransactionCoordinatorFencedException(string message) : base(message)
        {
        }

        public const int ErrorCode = 52;
        public int Code => ErrorCode;
    }
}
