#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>This broker ID is already in use.</para>
    /// </summary>
    public class DuplicateBrokerRegistrationException : Exception
    {
        public DuplicateBrokerRegistrationException()
        {
        }

        public DuplicateBrokerRegistrationException(string message) : base(message)
        {
        }

        public const int ErrorCode = 101;
        public int Code => ErrorCode;
    }
}
