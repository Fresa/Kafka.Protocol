#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The broker is not available.</para>
    /// </summary>
    public class BrokerNotAvailableException : Exception
    {
        public BrokerNotAvailableException()
        {
        }

        public BrokerNotAvailableException(string message) : base(message)
        {
        }

        public const int ErrorCode = 8;
        public int Code => ErrorCode;
    }
}
