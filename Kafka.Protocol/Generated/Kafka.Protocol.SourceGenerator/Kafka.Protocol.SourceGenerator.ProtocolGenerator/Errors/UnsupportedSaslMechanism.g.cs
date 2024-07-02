using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The broker does not support the requested SASL mechanism.</para>
    /// </summary>
    public class UnsupportedSaslMechanismException : Exception
    {
        public UnsupportedSaslMechanismException()
        {
        }

        public UnsupportedSaslMechanismException(string message) : base(message)
        {
        }

        public const int ErrorCode = 33;
        public int Code => ErrorCode;
    }
}
