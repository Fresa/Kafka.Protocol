using System;
using System.Diagnostics.Tracing;

namespace Kafka.Protocol.Logging
{
    [EventSource(Name = KafkaEventSource.Name)]
    public sealed class KafkaEventSource : EventSource
    {
        private KafkaEventSource()
        {
        }

        public const string Name = "Kafka.Protocol";

        public static class Keywords
        {
            public const EventKeywords Request = (EventKeywords)1;
            public const EventKeywords Response = (EventKeywords)(1 << 1);
        }

        private static class Events
        {
            public const int RequestHeaderWritten = 1;
            public const int RequestMessageWritten = 2;
            public const int RequestHeaderRead = 3;
            public const int RequestMessageRead = 4;
            public const int UnknownDataDetected = 5;
            public const int ResponseHeaderWritten = 6;
            public const int ResponseMessageWritten = 7;
            public const int ResponseHeaderRead = 8;
            public const int ResponseMessageRead = 9;
        }

        internal static readonly KafkaEventSource Log = new KafkaEventSource();

        [NonEvent]
        internal void RequestHeaderWritten(int size, RequestHeader header)
        {
            if (IsEnabled(EventLevel.Verbose, Keywords.Request))
            {
                RequestHeaderWritten(size,
                    header.ClientId?.Value,
                    header.IsFlexibleVersion,
                    header.CorrelationId.Value,
                    header.Version.Value,
                    header.RequestApiKey.Value,
                    header.RequestApiVersion.Value);
            }
        }

        [Event(Events.RequestHeaderWritten, Message = "{0} bytes", Level = EventLevel.Verbose, Keywords = Keywords.Request)]
        private void RequestHeaderWritten(int size, string? clientId, bool isFlexibleVersion, int correlationId, short version, short requestApiKey, short requestApiVersion)
        {
            WriteEvent(eventId: Events.RequestHeaderWritten, size, clientId, isFlexibleVersion, correlationId, version, requestApiKey, requestApiVersion);
        }

        [NonEvent]
        internal void RequestMessageWritten(int size, Message message)
        {
            if (IsEnabled(EventLevel.Verbose, Keywords.Request))
            {
                RequestMessageWritten(size,
                    message.GetType().Name, YamlSerializer.Serialize(message));
            }
        }

        [Event(Events.RequestMessageWritten, Message = "{1}: is {0} bytes", Level = EventLevel.Verbose, Keywords = Keywords.Request)]
        private void RequestMessageWritten(int size, string type, string message)
        {
            WriteEvent(Events.RequestMessageWritten, size, type, message);
        }

        [NonEvent]
        internal void RequestHeaderRead(int size, RequestHeader header)
        {
            if (IsEnabled(EventLevel.Verbose, Keywords.Request))
            {
                RequestHeaderRead(size, header.ClientId?.Value,
                    header.IsFlexibleVersion, header.CorrelationId.Value,
                    header.RequestApiKey.Value, header.RequestApiVersion.Value);
            }
        }

        [Event(Events.RequestHeaderRead, Message = "{0} bytes", Level = EventLevel.Verbose, Keywords = Keywords.Request)]
        private void RequestHeaderRead(int size, string? clientId, bool isFlexibleVersion, int correlationId, short requestApiKey, short requestApiVersion)
        {
            WriteEvent(eventId: Events.RequestHeaderRead, size, clientId, isFlexibleVersion, correlationId, requestApiKey, requestApiVersion);
        }

        [NonEvent]
        internal void RequestMessageRead(int size, Message message)
        {
            if (IsEnabled(EventLevel.Verbose, Keywords.Request))
            {
                RequestMessageRead(size, message.GetType().Name, YamlSerializer.Serialize(message));
            }
        }

        [Event(Events.RequestMessageRead, Message = "{1}: {0} bytes", Level = EventLevel.Verbose, Keywords = Keywords.Request)]
        private void RequestMessageRead(int size, string type, string message)
        {
            WriteEvent(Events.RequestMessageRead, size, type, message);
        }

        [Event(Events.UnknownDataDetected, Message = "Detected {0} unknown bytes, ignoring", Level = EventLevel.Warning, Keywords = Keywords.Request)]
        internal void UnknownDataDetected(int length, string data)
        {
            WriteEvent(Events.UnknownDataDetected, length, data);
        }


        [NonEvent]
        internal void ResponseHeaderWritten(int size, ResponseHeader header)
        {
            if (IsEnabled(EventLevel.Verbose, Keywords.Response))
            {
                ResponseHeaderWritten(size,
                    header.IsFlexibleVersion,
                    header.CorrelationId.Value,
                    header.Version.Value);
            }
        }
        [Event(Events.ResponseHeaderWritten, Message = "{0} bytes", Level = EventLevel.Verbose, Keywords = Keywords.Response)]
        private void ResponseHeaderWritten(int size, bool isFlexibleVersion, int correlationId, short version)
        {
            WriteEvent(eventId: Events.ResponseHeaderWritten, size, isFlexibleVersion, correlationId, version);
        }

        [NonEvent]
        internal void ResponseMessageWritten(int size, Message message)
        {
            if (IsEnabled(EventLevel.Verbose, Keywords.Response))
            {
                ResponseMessageWritten(size, message.GetType().Name, YamlSerializer.Serialize(message));
            }
        }
        [Event(Events.ResponseMessageWritten, Message = "{1}: {0} bytes", Level = EventLevel.Verbose, Keywords = Keywords.Response)]
        private void ResponseMessageWritten(int size, string type, string message)
        {
            WriteEvent(Events.ResponseMessageWritten, size, type, message);
        }

        [NonEvent]
        internal void ResponseHeaderRead(int size, ResponseHeader header)
        {
            if (IsEnabled(EventLevel.Verbose, Keywords.Response))
            {
                ResponseHeaderRead(size,
                    header.IsFlexibleVersion,
                    header.CorrelationId.Value,
                    header.Version.Value);
            }
        }

        [Event(Events.ResponseHeaderRead, Message = "Header is {0} bytes", Level = EventLevel.Verbose, Keywords = Keywords.Response)]
        private void ResponseHeaderRead(int size, bool isFlexibleVersion, int correlationId, short version)
        {
            WriteEvent(eventId: Events.ResponseHeaderRead, size, isFlexibleVersion, correlationId, version);
        }

        [NonEvent]
        internal void ResponseMessageRead(int size, Message message)
        {
            if (IsEnabled(EventLevel.Verbose, Keywords.Response))
            {
                ResponseMessageRead(size, message.GetType().Name, YamlSerializer.Serialize(message));
            }
        }

        [Event(Events.ResponseMessageRead, Message = "Message {1} is {0} bytes", Level = EventLevel.Verbose, Keywords = Keywords.Response)]
        private void ResponseMessageRead(int size, string type, string message)
        {
            WriteEvent(eventId: Events.ResponseMessageRead, size, type, message);
        }

        [NonEvent]
        private unsafe void WriteEvent(int eventId, int arg1, string? arg2, bool arg3, int arg4, short arg5, short arg6, short arg7)
        {
            arg2 ??= "";
            var arg3Int = arg3 ? 1 : 0;

            fixed (char* arg2Ptr = arg2)
            {
                const int numEventDatas = 7;
                var descrs = stackalloc EventData[numEventDatas];

                descrs[0] = new EventData
                {
                    DataPointer = (IntPtr)(&arg1),
                    Size = sizeof(int)
                };
                descrs[1] = new EventData
                {
                    DataPointer = (IntPtr)(arg2Ptr),
                    Size = (arg2.Length + 1) * sizeof(char)
                };
                descrs[2] = new EventData
                {
                    DataPointer = (IntPtr)(&arg3Int),
                    Size = sizeof(int)
                };
                descrs[3] = new EventData
                {
                    DataPointer = (IntPtr)(&arg4),
                    Size = sizeof(int)
                };
                descrs[4] = new EventData
                {
                    DataPointer = (IntPtr)(&arg5),
                    Size = sizeof(short)
                };
                descrs[5] = new EventData
                {
                    DataPointer = (IntPtr)(&arg6),
                    Size = sizeof(short)
                };
                descrs[6] = new EventData
                {
                    DataPointer = (IntPtr)(&arg7),
                    Size = sizeof(short)
                };

                WriteEventCore(eventId, numEventDatas, descrs);
            }
        }

        [NonEvent]
        private unsafe void WriteEvent(int eventId, int arg1, string? arg2, string? arg3)
        {
            arg2 ??= string.Empty;
            arg3 ??= string.Empty;

            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            {
                const int numEventDatas = 3;
                var descrs = stackalloc EventData[numEventDatas];

                descrs[0] = new EventData
                {
                    DataPointer = (IntPtr)(&arg1),
                    Size = sizeof(int)
                };
                descrs[1] = new EventData
                {
                    DataPointer = (IntPtr)(arg2Ptr),
                    Size = (arg2.Length + 1) * sizeof(char)
                };
                descrs[2] = new EventData
                {
                    DataPointer = (IntPtr)(arg3Ptr),
                    Size = (arg3.Length + 1) * sizeof(char)
                };

                WriteEventCore(eventId, numEventDatas, descrs);
            }
        }

        [NonEvent]
        private unsafe void WriteEvent(int eventId, int arg1, bool arg2, int arg3, short arg4)
        {
            var arg2Int = arg2 ? 1 : 0;
            const int numEventDatas = 4;
            var descrs = stackalloc EventData[numEventDatas];

            descrs[0] = new EventData
            {
                DataPointer = (IntPtr)(&arg1),
                Size = sizeof(int)
            };
            descrs[1] = new EventData
            {
                DataPointer = (IntPtr)(&arg2Int),
                Size = sizeof(int)
            };
            descrs[2] = new EventData
            {
                DataPointer = (IntPtr)(&arg3),
                Size = sizeof(int)
            };
            descrs[3] = new EventData
            {
                DataPointer = (IntPtr)(&arg4),
                Size = sizeof(short)
            };

            WriteEventCore(eventId, numEventDatas, descrs);

        }

        
    }
}