// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Requested credential would not meet criteria for acceptability.</para>
    /// </summary>
    public class UnacceptableCredentialException : Exception
    {
        public UnacceptableCredentialException()
        {
        }

        public UnacceptableCredentialException(string message) : base(message)
        {
        }

        public const int ErrorCode = 93;
        public int Code => ErrorCode;
    }
}
