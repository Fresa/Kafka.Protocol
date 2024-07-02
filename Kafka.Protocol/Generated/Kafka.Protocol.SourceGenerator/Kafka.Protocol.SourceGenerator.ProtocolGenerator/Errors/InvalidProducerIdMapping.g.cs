// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The producer attempted to use a producer id which is not currently assigned to its transactional id.</para>
    /// </summary>
    public class InvalidProducerIdMappingException : Exception
    {
        public InvalidProducerIdMappingException()
        {
        }

        public InvalidProducerIdMappingException(string message) : base(message)
        {
        }

        public const int ErrorCode = 49;
        public int Code => ErrorCode;
    }
}
