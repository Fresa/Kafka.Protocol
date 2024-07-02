// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The producer attempted to update a transaction while another concurrent operation on the same transaction was ongoing.</para>
    /// </summary>
    public class ConcurrentTransactionsException : Exception
    {
        public ConcurrentTransactionsException()
        {
        }

        public ConcurrentTransactionsException(string message) : base(message)
        {
        }

        public const int ErrorCode = 51;
        public int Code => ErrorCode;
    }
}
