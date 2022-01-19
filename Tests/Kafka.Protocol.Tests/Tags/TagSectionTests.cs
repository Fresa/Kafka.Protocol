using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Kafka.Protocol.Tags;
using Test.It.With.XUnit;
using Xunit;

namespace Kafka.Protocol.Tests.Tags
{
    namespace RecordBatchTests
    {
        public partial class Given_a_tag_section
        {
            public class When_serializing : XUnit2SpecificationAsync
            {
                private readonly TagSection _tagSection = new(
                    new TaggedField
                    {
                        Tag = 0,
                        Field = Int32.From(2)
                    });

                private int _actualLength;

                protected override async Task WhenAsync()
                {
                    var writer = new MemoryStream();
                    await using (writer.ConfigureAwait(false))
                    {
                        await _tagSection.WriteToAsync(writer, CancellationToken.None)
                            .ConfigureAwait(false);
                    }

                    _actualLength = writer.ToArray().Length;
                }

                [Fact]
                public void It_should_report_the_correct_length()
                {
                    _tagSection.GetSize().Should()
                        .BeGreaterThan(0)
                        .And.Be(_actualLength)
                        .And.Be(7);
                }
            }
        }

        public partial class Given_an_empty_tag_section
        {
            public class When_serializing : XUnit2SpecificationAsync
            {
                private readonly TagSection _tagSection = new();

                private int _actualLength;

                protected override async Task WhenAsync()
                {
                    var writer = new MemoryStream();
                    await using (writer.ConfigureAwait(false))
                    {
                        await _tagSection.WriteToAsync(writer, CancellationToken.None)
                            .ConfigureAwait(false);
                    }

                    _actualLength = writer.ToArray().Length;
                }

                [Fact]
                public void It_should_report_the_correct_length()
                {
                    _tagSection.GetSize().Should()
                        .BeGreaterThan(0)
                        .And.Be(_actualLength)
                        .And.Be(1);
                }
            }
        }
    }
}