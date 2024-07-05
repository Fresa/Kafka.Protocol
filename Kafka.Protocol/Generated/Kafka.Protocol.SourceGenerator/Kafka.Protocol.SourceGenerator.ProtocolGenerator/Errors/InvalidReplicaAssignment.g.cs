#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Replica assignment is invalid.</para>
    /// </summary>
    public class InvalidReplicaAssignmentException : Exception
    {
        public InvalidReplicaAssignmentException()
        {
        }

        public InvalidReplicaAssignmentException(string message) : base(message)
        {
        }

        public const int ErrorCode = 39;
        public int Code => ErrorCode;
    }
}
