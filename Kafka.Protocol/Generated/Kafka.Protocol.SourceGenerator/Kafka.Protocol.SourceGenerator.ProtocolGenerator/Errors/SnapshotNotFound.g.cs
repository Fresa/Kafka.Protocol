using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Requested snapshot was not found</para>
    /// </summary>
    public class SnapshotNotFoundException : Exception
    {
        public SnapshotNotFoundException()
        {
        }

        public SnapshotNotFoundException(string message) : base(message)
        {
        }

        public const int ErrorCode = 98;
        public int Code => ErrorCode;
    }
}
