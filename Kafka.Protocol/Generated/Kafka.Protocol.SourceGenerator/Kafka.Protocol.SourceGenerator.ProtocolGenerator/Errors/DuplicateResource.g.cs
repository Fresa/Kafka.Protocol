// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>A request illegally referred to the same resource twice.</para>
    /// </summary>
    public class DuplicateResourceException : Exception
    {
        public DuplicateResourceException()
        {
        }

        public DuplicateResourceException(string message) : base(message)
        {
        }

        public const int ErrorCode = 92;
        public int Code => ErrorCode;
    }
}
