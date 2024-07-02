// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Delegation Token requests are not allowed on PLAINTEXT/1-way SSL channels and on delegation token authenticated channels.</para>
    /// </summary>
    public class DelegationTokenRequestNotAllowedException : Exception
    {
        public DelegationTokenRequestNotAllowedException()
        {
        }

        public DelegationTokenRequestNotAllowedException(string message) : base(message)
        {
        }

        public const int ErrorCode = 64;
        public int Code => ErrorCode;
    }
}
