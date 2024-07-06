#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Delegation Token is not found on server.</para>
    /// </summary>
    public class DelegationTokenNotFoundException : Exception
    {
        public DelegationTokenNotFoundException()
        {
        }

        public DelegationTokenNotFoundException(string message) : base(message)
        {
        }

        public const int ErrorCode = 62;
        public int Code => ErrorCode;
    }
}
