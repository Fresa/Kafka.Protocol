// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.
using System;

namespace Kafka.Protocol
{
    /// <summary>
    /// <para>Specified Principal is not valid Owner/Renewer.</para>
    /// </summary>
    public class DelegationTokenOwnerMismatchException : Exception
    {
        public DelegationTokenOwnerMismatchException()
        {
        }

        public DelegationTokenOwnerMismatchException(string message) : base(message)
        {
        }

        public const int ErrorCode = 63;
        public int Code => ErrorCode;
    }
}
