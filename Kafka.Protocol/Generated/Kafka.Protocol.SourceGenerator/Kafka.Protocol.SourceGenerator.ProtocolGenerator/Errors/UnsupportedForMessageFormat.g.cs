#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The message format version on the broker does not support the request.</para>
    /// </summary>
    public class UnsupportedForMessageFormatException : Exception
    {
        public UnsupportedForMessageFormatException()
        {
        }

        public UnsupportedForMessageFormatException(string message) : base(message)
        {
        }

        public const int ErrorCode = 43;
        public int Code => ErrorCode;
    }
}
