using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kafka.Protocol.SourceGenerator.Json;

internal sealed class AutoTypeToStringConverter : JsonConverter<string>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType switch
        {
            JsonTokenType.Number => reader.TryGetInt64(out var value)
                ? value.ToString()
                : reader.GetDouble().ToString(CultureInfo.InvariantCulture),
            JsonTokenType.String => reader.GetString(),
            JsonTokenType.True => "true",
            JsonTokenType.False => "false",
            JsonTokenType.Null => "null",
            _ => throw new NotSupportedException(
                $"Token type {reader.TokenType} is not supported")
        };

    public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value?.ToString());
    }
}