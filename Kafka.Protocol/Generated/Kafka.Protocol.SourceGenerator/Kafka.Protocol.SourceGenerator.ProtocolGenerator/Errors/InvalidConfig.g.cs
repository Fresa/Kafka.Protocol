// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Configuration is invalid.</para>
    /// </summary>
    public class InvalidConfigException : Exception
    {
        public InvalidConfigException()
        {
        }

        public InvalidConfigException(string message) : base(message)
        {
        }

        public const int ErrorCode = 40;
        public int Code => ErrorCode;
    }
}
