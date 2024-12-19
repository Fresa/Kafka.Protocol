using System;
using System.Collections.Generic;
using FluentAssertions;
using Kafka.Protocol.Logging;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Tests.Logging;

public class YamlSerializerTests : XUnit2Specification
{
    [Theory]
    [MemberData(nameof(SimpleValues))]
    [MemberData(nameof(ComplexObjects))]
    public void Given_a_simple_object_when_serializing_it_should_be_serialized(object value, string expected)
    {
        YamlSerializer.Serialize(value).Should().Be(expected);
    }

    public static IEnumerable<object?[]> SimpleValues =>
        new List<object?[]>
        {
            new object[] { 1, "1" },
            new object[] { 1.2, "1.2" },
            new object[] { (decimal)1.2, "1.2" },
            new object[] { true, "true" },
            new object?[] { null, "null" },
            new object[] { "string", "string" },
            new object[] { new DateTimeOffset(2024, 2, 11, 8, 42, 54, TimeSpan.Zero), "2024-02-11T08:42:54.000Z" },
            new object[] { new DateTime(2024, 2, 11, 8, 42, 54), "2024-02-11T08:42:54.000Z" },
            new object[] { new TimeSpan(11, 8, 42, 54, 123), "11.08:42:54.123" },
            new object[] { Guid.Parse("1A3B944E-3632-467B-A53A-206305310BAE"), "1a3b944e-3632-467b-a53a-206305310bae" }
        };

    public static IEnumerable<object?[]> ComplexObjects =>
        new List<object?[]>
        {
            new object[]
            {
                new
                {
                    Foo = 1,
                    Bar = new
                    {
                        Foo = "fii"
                    },

                },
                """
                Foo: 1
                Bar: 
                  Foo: fii
                """
            },
            new object[]
            {
                new
                {
                    Foo = new[]
                    {
                        "bar",
                    }
                },
                """
                Foo: 
                  - bar
                """
            },
            new object[]
            {
                new[]
                {
                    "foo",
                    "bar"
                },
                """
                - foo
                - bar
                """
            },
            new object[]
            {
                new Dictionary<string, string>
                {
                    ["foo"] = "bar",
                    ["bar"] = "baz"
                },
                """
                ? foo
                : bar
                ? bar
                : baz
                """
            },
            new object[]
            {
                new List<KeyValuePair<string, string>>
                {
                    new("foo", "bar"),
                    new("foo", "baz")
                },
                """
                - ? foo
                  : bar
                - ? foo
                  : baz
                """
            },
            new object[]
            {
                new List<KeyValuePair<object, object>>
                {
                    new(new { Foo = "foo" }, new
                    {
                        Bar = "bar",
                        Baz = "fee"
                    }),
                    new(new { Foo = "foo" }, new
                    {
                        Bar = "baz",
                        Baz = "bar"
                    }),
                },
                """
                - ? Foo: foo
                  : Bar: bar
                    Baz: fee
                - ? Foo: foo
                  : Bar: baz
                    Baz: bar
                """
            }
        };
}