using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Kafka.Protocol.Logging
{
    internal static class YamlSerializer
    {
        private const string Empty = "";

        internal static string Serialize(object? obj) =>
            Serialize(obj, string.Empty, out _).Trim();
        private static string Serialize(object? obj, string indentation, out bool simple)
        {
            simple = true;
            if (obj is null)
                return "null";
            if (TrySerializeSimpleType(obj, out var simpleValue))
            {
                return simpleValue;
            }

            simple = false;
            var type = obj.GetType();
            var isMap = type.GetInterfaces().Any(@interface =>
                (@interface.IsGenericType &&
                 @interface.GetGenericTypeDefinition() ==
                 typeof(IDictionary<,>)) ||
                @interface == typeof(IDictionary)
            );

            if (obj is IEnumerable list)
            {
                return string.Join(Environment.NewLine,
                    list.Cast<object?>()
                        .Where(item => item != null)
                        .Cast<object>().Select(
                            item => isMap
                                ? Serialize(item, indentation, out _)
                                : $"{indentation}- {Serialize(item, indentation + "  ", out _).TrimStart()}"));
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() ==
                typeof(KeyValuePair<,>))
            {
                var key = type
                    .GetProperty("Key")!.GetValue(obj);
                var value = type
                    .GetProperty("Value")!.GetValue(obj);

                return $"{indentation}? {Serialize(key, indentation + "  ", out _)}{Environment.NewLine}" +
                       $"{indentation}: {Serialize(value, indentation + "  ", out _)}";
            }

            var properties = type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(info => info.CanRead && info.GetIndexParameters().Length == 0)
                .ToList();

            return properties.Any()
                ? string.Join(Environment.NewLine, properties.Select(
                    property =>
                    {
                        var value = property.GetValue(obj, null);
                        var serializedValue =
                            Serialize(value, indentation + "  ", out var isSimple);
                        return
                            $"{indentation}{property.Name}: {(isSimple ? string.Empty : Environment.NewLine)}{serializedValue}";
                    }))
                : string.Empty;
        }

        private static readonly ConcurrentDictionary<Type, bool> IsSimpleTypeCache = new ConcurrentDictionary<Type, bool>();

        private static bool TrySerializeSimpleType(object obj, [NotNullWhen(true)] out string? serializedValue)
        {
            var type = obj.GetType();
            while (true)
            {
                serializedValue = obj switch
                {
                    string str => str,
                    bool boolValue => boolValue ? "true" : "false",
                    decimal value => value.ToString(NumberFormatInfo.InvariantInfo),
                    double value => value.ToString(NumberFormatInfo.InvariantInfo),
                    DateTimeOffset value => value.ToString("yyyy-MM-dd'T'HH:mm:ss.fffZ"),
                    DateTime value => value.ToString("yyyy-MM-dd'T'HH:mm:ss.fffZ"),
                    TimeSpan value => value.ToString(@"d\.hh\:mm\:ss\.fff"),
                    Guid guid => guid.ToString(),
                    _ when type.IsPrimitive || type.IsEnum => obj.ToString(),
                    _ => null
                };

                if (serializedValue != null)
                {
                    return true;
                }

                type = Nullable.GetUnderlyingType(type);
                if (type != null)
                {
                    continue;
                }

                serializedValue = null;
                return false;
            }
        }
    }
}