using System;
using System.Diagnostics.Tracing;
using System.Linq;
using Kafka.Protocol.Logging;
using Xunit.Abstractions;

namespace Kafka.Protocol.Tests;

internal sealed class LogEventListener(ITestOutputHelper outputHelper)
    : EventListener
{
    protected override void OnEventSourceCreated(EventSource eventSource)
    {
        if (eventSource.Name == LogEventSource.Name)
        {
            EnableEvents(eventSource, EventLevel.LogAlways);
        }
        base.OnEventSourceCreated(eventSource);
    }

    private const string Indentation = "  ";

    private static readonly string PayloadValueMultilineSeparator =
        Environment.NewLine + Indentation + Indentation;

    protected override void OnEventWritten(EventWrittenEventArgs eventData)
    {
        var data = string.Join(Environment.NewLine, eventData.PayloadNames?.Select((payloadName, i) =>
        {
            var payload = eventData.Payload?[i];
            var formattedPayload = payload switch
            {
                string strPayload =>
                    strPayload.Contains(Environment.NewLine)
                        ? $"{PayloadValueMultilineSeparator}{strPayload.Replace(Environment.NewLine, PayloadValueMultilineSeparator)}"
                        : strPayload,
                _ => payload?.ToString()
            };
            return $"{Indentation}{payloadName}: {formattedPayload}";
        }) ?? Array.Empty<string>());
            
        outputHelper.WriteLine(
            $"{eventData.EventName} [{eventData.Level.ToString().ToUpper()}]: {GetFormattedMessage(eventData)} {GetFormattedEventPayload(eventData)}");
            
        base.OnEventWritten(eventData);
    }

    private static string GetFormattedMessage(EventWrittenEventArgs eventData) =>
        string.Format(eventData.Message ?? string.Empty,
            eventData.Payload?.ToArray() ?? []);

    private static string GetFormattedEventPayload(EventWrittenEventArgs eventData)
    {
        var data = string.Join(Environment.NewLine, eventData.PayloadNames?.Select((payloadName, i) =>
        {
            var payload = eventData.Payload?[i];
            var formattedPayload = payload switch
            {
                string strPayload =>
                    strPayload.Contains(Environment.NewLine)
                        ? $"{PayloadValueMultilineSeparator}{strPayload.Replace(Environment.NewLine, PayloadValueMultilineSeparator)}"
                        : strPayload,
                _ => payload?.ToString()
            };
            return $"{Indentation}{payloadName}: {formattedPayload}";
        }) ?? Array.Empty<string>());
        return data == string.Empty ? string.Empty : Environment.NewLine + data;
    }
}