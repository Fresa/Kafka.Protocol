#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Eligible topic partition leaders are not available.</para>
    /// </summary>
    public class EligibleLeadersNotAvailableException : Exception
    {
        public EligibleLeadersNotAvailableException()
        {
        }

        public EligibleLeadersNotAvailableException(string message) : base(message)
        {
        }

        public const int ErrorCode = 83;
        public int Code => ErrorCode;
    }
}
