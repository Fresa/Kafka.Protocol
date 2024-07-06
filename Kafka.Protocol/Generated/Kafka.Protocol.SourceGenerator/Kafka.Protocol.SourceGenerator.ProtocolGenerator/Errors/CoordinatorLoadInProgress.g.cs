#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The coordinator is loading and hence can't process requests.</para>
    /// </summary>
    public class CoordinatorLoadInProgressException : Exception
    {
        public CoordinatorLoadInProgressException()
        {
        }

        public CoordinatorLoadInProgressException(string message) : base(message)
        {
        }

        public const int ErrorCode = 14;
        public int Code => ErrorCode;
    }
}
