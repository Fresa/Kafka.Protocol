#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Broker epoch has changed.</para>
    /// </summary>
    public class StaleBrokerEpochException : Exception
    {
        public StaleBrokerEpochException()
        {
        }

        public StaleBrokerEpochException(string message) : base(message)
        {
        }

        public const int ErrorCode = 77;
        public int Code => ErrorCode;
    }
}
