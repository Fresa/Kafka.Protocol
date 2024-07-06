#nullable enable
#pragma warning disable 1591
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>The clusterId in the request does not match that found on the server</para>
    /// </summary>
    public class InconsistentClusterIdException : Exception
    {
        public InconsistentClusterIdException()
        {
        }

        public InconsistentClusterIdException(string message) : base(message)
        {
        }

        public const int ErrorCode = 104;
        public int Code => ErrorCode;
    }
}
