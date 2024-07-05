#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Request is not valid given the current SASL state.</para>
    /// </summary>
    public class IllegalSaslStateException : Exception
    {
        public IllegalSaslStateException()
        {
        }

        public IllegalSaslStateException(string message) : base(message)
        {
        }

        public const int ErrorCode = 34;
        public int Code => ErrorCode;
    }
}
