#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The request included message batch larger than the configured segment size on the server.</para>
    /// </summary>
    public class RecordListTooLargeException : Exception
    {
        public RecordListTooLargeException()
        {
        }

        public RecordListTooLargeException(string message) : base(message)
        {
        }

        public const int ErrorCode = 18;
        public int Code => ErrorCode;
    }
}
