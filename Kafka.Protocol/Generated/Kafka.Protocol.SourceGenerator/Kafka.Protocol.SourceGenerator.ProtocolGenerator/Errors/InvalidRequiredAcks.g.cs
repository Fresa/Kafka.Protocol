#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Produce request specified an invalid value for required acks.</para>
    /// </summary>
    public class InvalidRequiredAcksException : Exception
    {
        public InvalidRequiredAcksException()
        {
        }

        public InvalidRequiredAcksException(string message) : base(message)
        {
        }

        public const int ErrorCode = 21;
        public int Code => ErrorCode;
    }
}
