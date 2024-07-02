// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Leader election not needed for topic partition.</para>
    /// </summary>
    public class ElectionNotNeededException : Exception
    {
        public ElectionNotNeededException()
        {
        }

        public ElectionNotNeededException(string message) : base(message)
        {
        }

        public const int ErrorCode = 84;
        public int Code => ErrorCode;
    }
}
