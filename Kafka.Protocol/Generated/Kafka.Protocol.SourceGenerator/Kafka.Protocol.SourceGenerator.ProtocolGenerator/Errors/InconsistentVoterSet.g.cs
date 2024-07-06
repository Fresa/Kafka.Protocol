#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Indicates that the either the sender or recipient of a voter-only request is not one of the expected voters</para>
    /// </summary>
    public class InconsistentVoterSetException : Exception
    {
        public InconsistentVoterSetException()
        {
        }

        public InconsistentVoterSetException(string message) : base(message)
        {
        }

        public const int ErrorCode = 94;
        public int Code => ErrorCode;
    }
}
