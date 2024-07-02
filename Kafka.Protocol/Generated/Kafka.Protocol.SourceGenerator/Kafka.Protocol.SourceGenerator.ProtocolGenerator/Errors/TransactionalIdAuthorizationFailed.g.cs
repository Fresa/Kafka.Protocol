using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Transactional Id authorization failed.</para>
    /// </summary>
    public class TransactionalIdAuthorizationFailedException : Exception
    {
        public TransactionalIdAuthorizationFailedException()
        {
        }

        public TransactionalIdAuthorizationFailedException(string message) : base(message)
        {
        }

        public const int ErrorCode = 53;
        public int Code => ErrorCode;
    }
}
