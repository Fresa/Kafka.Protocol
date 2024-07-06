#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The group is rebalancing, so a rejoin is needed.</para>
    /// </summary>
    public class RebalanceInProgressException : Exception
    {
        public RebalanceInProgressException()
        {
        }

        public RebalanceInProgressException(string message) : base(message)
        {
        }

        public const int ErrorCode = 27;
        public int Code => ErrorCode;
    }
}
