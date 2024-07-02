// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Requested position is not greater than or equal to zero, and less than the size of the snapshot.</para>
    /// </summary>
    public class PositionOutOfRangeException : Exception
    {
        public PositionOutOfRangeException()
        {
        }

        public PositionOutOfRangeException(string message) : base(message)
        {
        }

        public const int ErrorCode = 99;
        public int Code => ErrorCode;
    }
}
