// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The version of API is not supported.</para>
    /// </summary>
    public class UnsupportedVersionException : Exception
    {
        public UnsupportedVersionException()
        {
        }

        public UnsupportedVersionException(string message) : base(message)
        {
        }

        public const int ErrorCode = 35;
        public int Code => ErrorCode;
    }
}
