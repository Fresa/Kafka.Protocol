// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The transactionalId could not be found</para>
    /// </summary>
    public class TransactionalIdNotFoundException : Exception
    {
        public TransactionalIdNotFoundException()
        {
        }

        public TransactionalIdNotFoundException(string message) : base(message)
        {
        }

        public const int ErrorCode = 105;
        public int Code => ErrorCode;
    }
}
