#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>This exception is raised by the broker if it could not locate the producer metadata associated with the producerId in question. This could happen if, for instance, the producer's records were deleted because their retention time had elapsed. Once the last records of the producerId are removed, the producer's metadata is removed from the broker, and future appends by the producer will return this exception.</para>
    /// </summary>
    public class UnknownProducerIdException : Exception
    {
        public UnknownProducerIdException()
        {
        }

        public UnknownProducerIdException(string message) : base(message)
        {
        }

        public const int ErrorCode = 59;
        public int Code => ErrorCode;
    }
}
