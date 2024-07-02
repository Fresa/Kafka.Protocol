// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Deleting offsets of a topic is forbidden while the consumer group is actively subscribed to it.</para>
    /// </summary>
    public class GroupSubscribedToTopicException : Exception
    {
        public GroupSubscribedToTopicException()
        {
        }

        public GroupSubscribedToTopicException(string message) : base(message)
        {
        }

        public const int ErrorCode = 86;
        public int Code => ErrorCode;
    }
}
