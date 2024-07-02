// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The request attempted to perform an operation on an invalid topic.</para>
    /// </summary>
    public class InvalidTopicExceptionException : Exception
    {
        public InvalidTopicExceptionException()
        {
        }

        public InvalidTopicExceptionException(string message) : base(message)
        {
        }

        public const int ErrorCode = 17;
        public int Code => ErrorCode;
    }
}
