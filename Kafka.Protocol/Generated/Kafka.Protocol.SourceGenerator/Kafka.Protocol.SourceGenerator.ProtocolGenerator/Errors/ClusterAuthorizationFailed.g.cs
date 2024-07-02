// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Cluster authorization failed.</para>
    /// </summary>
    public class ClusterAuthorizationFailedException : Exception
    {
        public ClusterAuthorizationFailedException()
        {
        }

        public ClusterAuthorizationFailedException(string message) : base(message)
        {
        }

        public const int ErrorCode = 31;
        public int Code => ErrorCode;
    }
}
