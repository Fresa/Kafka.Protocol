// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The given broker ID was not registered.</para>
    /// </summary>
    public class BrokerIdNotRegisteredException : Exception
    {
        public BrokerIdNotRegisteredException()
        {
        }

        public BrokerIdNotRegisteredException(string message) : base(message)
        {
        }

        public const int ErrorCode = 102;
        public int Code => ErrorCode;
    }
}
