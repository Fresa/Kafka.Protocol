#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Replication factor is below 1 or larger than the number of available brokers.</para>
    /// </summary>
    public class InvalidReplicationFactorException : Exception
    {
        public InvalidReplicationFactorException()
        {
        }

        public InvalidReplicationFactorException(string message) : base(message)
        {
        }

        public const int ErrorCode = 38;
        public int Code => ErrorCode;
    }
}
