using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Delegation Token authorization failed.</para>
    /// </summary>
    public class DelegationTokenAuthorizationFailedException : Exception
    {
        public DelegationTokenAuthorizationFailedException()
        {
        }

        public DelegationTokenAuthorizationFailedException(string message) : base(message)
        {
        }

        public const int ErrorCode = 65;
        public int Code => ErrorCode;
    }
}
