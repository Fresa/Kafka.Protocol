#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Number of partitions is below 1.</para>
    /// </summary>
    public class InvalidPartitionsException : Exception
    {
        public InvalidPartitionsException()
        {
        }

        public InvalidPartitionsException(string message) : base(message)
        {
        }

        public const int ErrorCode = 37;
        public int Code => ErrorCode;
    }
}
