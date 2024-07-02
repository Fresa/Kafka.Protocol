// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Producer attempted to produce with an old epoch.</para>
    /// </summary>
    public class InvalidProducerEpochException : Exception
    {
        public InvalidProducerEpochException()
        {
        }

        public InvalidProducerEpochException(string message) : base(message)
        {
        }

        public const int ErrorCode = 47;
        public int Code => ErrorCode;
    }
}
