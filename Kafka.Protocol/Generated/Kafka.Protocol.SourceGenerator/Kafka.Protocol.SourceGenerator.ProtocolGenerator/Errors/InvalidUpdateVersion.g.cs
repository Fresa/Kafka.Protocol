// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The given update version was invalid.</para>
    /// </summary>
    public class InvalidUpdateVersionException : Exception
    {
        public InvalidUpdateVersionException()
        {
        }

        public InvalidUpdateVersionException(string message) : base(message)
        {
        }

        public const int ErrorCode = 95;
        public int Code => ErrorCode;
    }
}
