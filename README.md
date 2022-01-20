# Kafka.Protocol
Protocol definitions for Kafka.

[![Continuous Delivery](https://github.com/Fresa/Kafka.Protocol/actions/workflows/ci.yml/badge.svg)](https://github.com/Fresa/Kafka.Protocol/actions/workflows/ci.yml)

## Download
https://www.nuget.org/packages/kafka.protocol

## Getting Started
[`KafkaProtocol.cs`](https://github.com/Fresa/Kafka.Protocol/blob/master/Kafka.Protocol/KafkaProtocol.cs) contains auto-generated protocol definitions based on the official [`message specifications`](https://github.com/apache/kafka/tree/trunk/clients/src/main/resources/common/message) found in the offical [`apache/kafka`](https://github.com/apache/kafka) repository together with generated basic value types extracted from the [`Kafka protocol guide`](http://kafka.apache.org/protocol.html). The Record Batch and Record are not available as specifications so these are manually rolled and provided based on the documentation found [`here`](http://kafka.apache.org/documentation/#recordbatch).

There is a [`test framework`](https://github.com/Fresa/Kafka.TestFramework) for integration testing clients like [`Confluent.Kafka`](https://github.com/confluentinc/confluent-kafka-dotnet) etc.

### v2.x
This version introduce some breaking changes due to breaking changes in the Kafka Protocol definition itself (mostly subtle property names changes), see the release notes for further details. 

A major improvement is supporting optional tagged fields, which also introduces flexible message versions which includes a more effecient way of serializing some primitives. More information kan be found in [KIP-482](https://cwiki.apache.org/confluence/display/KAFKA/KIP-482%3A+The+Kafka+Protocol+should+Support+Optional+Tagged+Fields).