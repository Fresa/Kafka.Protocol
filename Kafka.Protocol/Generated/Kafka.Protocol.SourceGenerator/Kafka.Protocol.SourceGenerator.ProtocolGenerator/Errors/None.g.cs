#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    public class NoneException : Exception
    {
        public NoneException()
        {
        }

        public NoneException(string message) : base(message)
        {
        }

        public const int ErrorCode = 0;
        public int Code => ErrorCode;
    }
}
