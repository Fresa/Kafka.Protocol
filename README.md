# Kafka.Protocol
Protocol definitions for Kafka.

[![Continuous Delivery](https://github.com/Fresa/Kafka.Protocol/actions/workflows/ci.yml/badge.svg)](https://github.com/Fresa/Kafka.Protocol/actions/workflows/ci.yml)

Kafka version: [**3.9.0**](https://github.com/apache/kafka/releases/tag/3.9.0)

## Download
https://www.nuget.org/packages/kafka.protocol

## Getting Started
The namespace `Kafka.Protocol` contains generated protocol definitions based on the [`message specifications`](https://github.com/apache/kafka/tree/trunk/clients/src/main/resources/common/message) found in the [`apache/kafka`](https://github.com/apache/kafka) repository together with basic value types extracted from the [`Kafka protocol guide`](http://kafka.apache.org/protocol.html). The Record Batch and Record are manually rolled and provided based on the documentation found [`here`](http://kafka.apache.org/documentation/#recordbatch).

There is a [`test framework`](https://github.com/Fresa/Kafka.TestFramework) for integration testing clients like [`Confluent.Kafka`](https://github.com/confluentinc/confluent-kafka-dotnet) etc.

### Logging
Log events are generated using an [`EventSource`](Kafka.Protocol/Logging/LogEventSource.cs) that can be subscribed on using an [`EventListener`](https://learn.microsoft.com/en-us/dotnet/core/diagnostics/eventsource-collect-and-view-traces#eventlistener). Have a look at [`LogEventListener`](tests/Kafka.Protocol.Tests/LogEventListener.cs) for an example.

Avoid subscribing on verbose log events in a production environment as it includes yaml serialized .NET Kafka message representations which can be quite resource intense and can add a substantial amount of latency. Pretty useful though for test purposes if you need visualization of what data the messages contain in a human readable way.
