#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The controller moved to another broker.</para>
    /// </summary>
    public class StaleControllerEpochException : Exception
    {
        public StaleControllerEpochException()
        {
        }

        public StaleControllerEpochException(string message) : base(message)
        {
        }

        public const int ErrorCode = 11;
        public int Code => ErrorCode;
    }
}
