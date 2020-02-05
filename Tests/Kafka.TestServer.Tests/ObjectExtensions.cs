using System;

namespace Kafka.TestServer.Tests
{
    internal static class ObjectExtensions
    {
        internal static T WithAction<T>(this T @object, Action<T> invoke)
        {
            invoke(@object);
            return @object;
        }
    }
}