// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Request principal deserialization failed during forwarding. This indicates an internal error on the broker cluster security setup.</para>
    /// </summary>
    public class PrincipalDeserializationFailureException : Exception
    {
        public PrincipalDeserializationFailureException()
        {
        }

        public PrincipalDeserializationFailureException(string message) : base(message)
        {
        }

        public const int ErrorCode = 97;
        public int Code => ErrorCode;
    }
}
