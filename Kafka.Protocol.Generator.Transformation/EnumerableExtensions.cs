using System;
using System.Collections.Generic;
using System.Linq;

namespace Kafka.Protocol.Generator.Transformation
{
    public static class EnumerableExtensions
    {
        internal static IDictionary<int, T> WithIndex<T>(this IEnumerable<T> list)
        {
            return list
                .Select((item, i) =>
                    new { Index = i, Item = item })
                .ToDictionary(
                    arg => arg.Index,
                    arg => arg.Item);
        }

        public static void ForEach<T>(this IEnumerable<T> list, Action<T, int> action)
        {
            foreach (var item in list.WithIndex())
            {
                action.Invoke(item.Value, item.Key);
            }
        }
    }
}