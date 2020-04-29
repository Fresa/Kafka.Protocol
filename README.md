# Kafka.Protocol
Protocol definitions for Kafka.

[![Build status](https://ci.appveyor.com/api/projects/status/2grcq7xl5c4iswq8?svg=true)](https://ci.appveyor.com/project/Fresa/kafka-protocol)

[![Build history](https://buildstats.info/appveyor/chart/Fresa/kafka-protocol)](https://ci.appveyor.com/project/Fresa/kafka-protocol/history)

## Download
https://www.nuget.org/packages/kafka-protocol

## Getting Started
[`KafkaProtocol.cs`](https://github.com/Fresa/Kafka.Protocol/blob/master/Kafka.Protocol/KafkaProtocol.cs) contains auto-generated protocol definitions based on the official [`message specifications`](https://github.com/apache/kafka/tree/trunk/clients/src/main/resources/common/message) found in the offical [`apache/kafka`](https://github.com/apache/kafka) repository together with generated basic value types extracted from the [`Kafka protocol guide`](http://kafka.apache.org/protocol.html). The Record Batch and Record are not available as specifications so these manually rolled and provided based on the documentation found [`here`](http://kafka.apache.org/documentation/#recordbatch).

A protocol [`reader`](https://github.com/Fresa/Kafka.Protocol/blob/master/Kafka.Protocol/KafkaReader.cs) and [`writer`](https://github.com/Fresa/Kafka.Protocol/blob/master/Kafka.Protocol/KafkaWriter.cs) is also available.

There is a [`test framework`](https://github.com/Fresa/Kafka.TestFramework) for integration testing clients like [`Confluent.Kafka`](https://github.com/confluentinc/confluent-kafka-dotnet) etc.