using System;
using System.Threading;
using Test.It.With.XUnit;
using Xunit.Abstractions;

namespace Kafka.Protocol.Tests
{
    public abstract class
        UnitTestSpecificationAsync : XUnit2SpecificationAsync
    {
        protected UnitTestSpecificationAsync()
        {
            CancellationToken = new CancellationTokenSource(TimeOut).Token;
        }

        protected UnitTestSpecificationAsync(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
            CancellationToken = new CancellationTokenSource(TimeOut).Token;
        }

        protected virtual CancellationToken CancellationToken { get; }
        protected TimeSpan TimeOut { get; } = TimeSpan.FromSeconds(3);
    }
}