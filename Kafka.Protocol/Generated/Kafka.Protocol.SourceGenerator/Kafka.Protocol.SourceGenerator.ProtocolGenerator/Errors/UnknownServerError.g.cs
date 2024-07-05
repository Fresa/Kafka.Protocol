#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The server experienced an unexpected error when processing the request.</para>
    /// </summary>
    public class UnknownServerErrorException : Exception
    {
        public UnknownServerErrorException()
        {
        }

        public UnknownServerErrorException(string message) : base(message)
        {
        }

        public const int ErrorCode = -1;
        public int Code => ErrorCode;
    }
}
