#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The user-specified log directory is not found in the broker config.</para>
    /// </summary>
    public class LogDirNotFoundException : Exception
    {
        public LogDirNotFoundException()
        {
        }

        public LogDirNotFoundException(string message) : base(message)
        {
        }

        public const int ErrorCode = 57;
        public int Code => ErrorCode;
    }
}
