#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>This record has failed the validation on broker and hence will be rejected.</para>
    /// </summary>
    public class InvalidRecordException : Exception
    {
        public InvalidRecordException()
        {
        }

        public InvalidRecordException(string message) : base(message)
        {
        }

        public const int ErrorCode = 87;
        public int Code => ErrorCode;
    }
}
