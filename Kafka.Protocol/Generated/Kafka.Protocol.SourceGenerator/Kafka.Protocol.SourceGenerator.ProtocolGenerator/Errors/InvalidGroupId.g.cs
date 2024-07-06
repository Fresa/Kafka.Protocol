#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The configured groupId is invalid.</para>
    /// </summary>
    public class InvalidGroupIdException : Exception
    {
        public InvalidGroupIdException()
        {
        }

        public InvalidGroupIdException(string message) : base(message)
        {
        }

        public const int ErrorCode = 24;
        public int Code => ErrorCode;
    }
}
