using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Supplied principalType is not supported.</para>
    /// </summary>
    public class InvalidPrincipalTypeException : Exception
    {
        public InvalidPrincipalTypeException()
        {
        }

        public InvalidPrincipalTypeException(string message) : base(message)
        {
        }

        public const int ErrorCode = 67;
        public int Code => ErrorCode;
    }
}
