// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The group is not empty.</para>
    /// </summary>
    public class NonEmptyGroupException : Exception
    {
        public NonEmptyGroupException()
        {
        }

        public NonEmptyGroupException(string message) : base(message)
        {
        }

        public const int ErrorCode = 68;
        public int Code => ErrorCode;
    }
}
