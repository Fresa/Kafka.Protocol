#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The coordinator is not aware of this member.</para>
    /// </summary>
    public class UnknownMemberIdException : Exception
    {
        public UnknownMemberIdException()
        {
        }

        public UnknownMemberIdException(string message) : base(message)
        {
        }

        public const int ErrorCode = 25;
        public int Code => ErrorCode;
    }
}
