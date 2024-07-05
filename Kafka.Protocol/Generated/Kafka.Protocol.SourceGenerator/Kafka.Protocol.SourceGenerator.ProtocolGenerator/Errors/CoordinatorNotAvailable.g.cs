#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The coordinator is not available.</para>
    /// </summary>
    public class CoordinatorNotAvailableException : Exception
    {
        public CoordinatorNotAvailableException()
        {
        }

        public CoordinatorNotAvailableException(string message) : base(message)
        {
        }

        public const int ErrorCode = 15;
        public int Code => ErrorCode;
    }
}
