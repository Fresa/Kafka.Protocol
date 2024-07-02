// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The broker received an out of order sequence number.</para>
    /// </summary>
    public class OutOfOrderSequenceNumberException : Exception
    {
        public OutOfOrderSequenceNumberException()
        {
        }

        public OutOfOrderSequenceNumberException(string message) : base(message)
        {
        }

        public const int ErrorCode = 45;
        public int Code => ErrorCode;
    }
}
