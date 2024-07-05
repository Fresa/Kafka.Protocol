#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The preferred leader was not available.</para>
    /// </summary>
    public class PreferredLeaderNotAvailableException : Exception
    {
        public PreferredLeaderNotAvailableException()
        {
        }

        public PreferredLeaderNotAvailableException(string message) : base(message)
        {
        }

        public const int ErrorCode = 80;
        public int Code => ErrorCode;
    }
}
