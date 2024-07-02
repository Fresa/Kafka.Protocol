// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>This is not the correct coordinator.</para>
    /// </summary>
    public class NotCoordinatorException : Exception
    {
        public NotCoordinatorException()
        {
        }

        public NotCoordinatorException(string message) : base(message)
        {
        }

        public const int ErrorCode = 16;
        public int Code => ErrorCode;
    }
}
