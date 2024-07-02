// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The fetch session ID was not found.</para>
    /// </summary>
    public class FetchSessionIdNotFoundException : Exception
    {
        public FetchSessionIdNotFoundException()
        {
        }

        public FetchSessionIdNotFoundException(string message) : base(message)
        {
        }

        public const int ErrorCode = 70;
        public int Code => ErrorCode;
    }
}
