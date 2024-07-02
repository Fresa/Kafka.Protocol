using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Eligible topic partition leaders are not available.</para>
    /// </summary>
    public class EligibleLeadersNotAvailableException : Exception
    {
        public EligibleLeadersNotAvailableException()
        {
        }

        public EligibleLeadersNotAvailableException(string message) : base(message)
        {
        }

        public const int ErrorCode = 83;
        public int Code => ErrorCode;
    }
}
