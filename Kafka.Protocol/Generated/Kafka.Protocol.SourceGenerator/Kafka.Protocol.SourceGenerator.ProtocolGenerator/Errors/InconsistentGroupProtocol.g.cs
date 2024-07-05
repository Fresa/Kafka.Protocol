#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The group member's supported protocols are incompatible with those of existing members or first group member tried to join with empty protocol type or empty protocol list.</para>
    /// </summary>
    public class InconsistentGroupProtocolException : Exception
    {
        public InconsistentGroupProtocolException()
        {
        }

        public InconsistentGroupProtocolException(string message) : base(message)
        {
        }

        public const int ErrorCode = 23;
        public int Code => ErrorCode;
    }
}
