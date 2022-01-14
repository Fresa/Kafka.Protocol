using System;
using System.Linq;

namespace Kafka.Protocol.Generator.Helpers.Definitions
{
    public class VersionRange
    {
        public VersionRange()
        {
        }

        public VersionRange(int from, int? to = null)
        {
            From = from;
            To = to;
        }

        public int? From { get; }
        public int? To { get; }

        public bool None =>
            !From.HasValue && !To.HasValue ||
            From > To;
        public bool Full => 
            From == 0 && To is null or int.MaxValue;

        public string GetExpression(string variable) 
        {
            if (None)
            {
                return "false";
            }

            if (Full)
            {
                return "true";
            }

            return To switch
            {
                null => $"{variable} >= {From}",
                _ => $"{variable} >= {From} && {variable} <= {To}"
            };
        }

        public VersionRange Except(VersionRange versionRange)
        {
            if (versionRange.From < From ||
                versionRange.To > To ||
                versionRange.To is not null && To is null)
            {
                throw new InvalidOperationException(
                    "The excepted version range must be a subset of the current range");
            }

            if (None || versionRange.Full ||
                From == versionRange.From)
            {
                return new VersionRange();
            }
            
            if (versionRange.None)
            {
                return this;
            }
            
            return new VersionRange((int)From!,
                To is null
                    ? versionRange.From
                    : Math.Min((int)To, versionRange.From ?? int.MaxValue));
        }

        public static VersionRange Parse(string versionRangeExpression)
        {
            const string expectedFormatMessage = "Expected version range expression. Example: none, 0+, 1-2";

            if (string.IsNullOrEmpty(versionRangeExpression))
            {
                throw new ArgumentNullException(
                    nameof(versionRangeExpression),
                    expectedFormatMessage);
            }

            if (versionRangeExpression.Equals("none"))
            {
                return new VersionRange();
            }
            
            var versions = versionRangeExpression.Split(
                new[] {'-', '+'},
                StringSplitOptions.RemoveEmptyEntries);

            if (versions.Length > 2)
            {
                throw new ArgumentException(
                    expectedFormatMessage,
                    nameof(versionRangeExpression));
            }

            if (int.TryParse(versions.First(), out var from) == false)
            {
                throw new ArgumentException(
                    $"{versions.First()} is not a number. {expectedFormatMessage}",
                    nameof(versionRangeExpression));
            }

            if (versions.Length == 1)
            {
                return new VersionRange(from);
            }

            if (int.TryParse(versions.Last(), out var to) == false)
            {
                throw new ArgumentException(
                    $"{versions.Last()} is not a number. {expectedFormatMessage}",
                    nameof(versionRangeExpression));
            }

            return new VersionRange(from, to);
        }
    }
}