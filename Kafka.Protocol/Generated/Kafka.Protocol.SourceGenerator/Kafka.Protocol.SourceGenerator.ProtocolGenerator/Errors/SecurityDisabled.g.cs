using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Security features are disabled.</para>
    /// </summary>
    public class SecurityDisabledException : Exception
    {
        public SecurityDisabledException()
        {
        }

        public SecurityDisabledException(string message) : base(message)
        {
        }

        public const int ErrorCode = 54;
        public int Code => ErrorCode;
    }
}
