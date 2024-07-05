#nullable enable
// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Unable to update finalized features due to an unexpected server error.</para>
    /// </summary>
    public class FeatureUpdateFailedException : Exception
    {
        public FeatureUpdateFailedException()
        {
        }

        public FeatureUpdateFailedException(string message) : base(message)
        {
        }

        public const int ErrorCode = 96;
        public int Code => ErrorCode;
    }
}
