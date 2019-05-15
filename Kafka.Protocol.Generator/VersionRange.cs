using System;
using System.Linq;

namespace Kafka.Protocol.Generator
{
    public class VersionRange
    {
        private int From { get; }
        private int To { get; }

        internal VersionRange(int from, int to)
        {
            From = from;
            To = to;
        }

        public static VersionRange Parse(string versionRangeExpression)
        {
            const string expectedFormatMessage = "Expected version range expression. Example: 0+, 1-2";

            if (string.IsNullOrEmpty(versionRangeExpression))
            {
                throw new ArgumentNullException(nameof(versionRangeExpression), expectedFormatMessage);
            }

            var versions = versionRangeExpression.Split(new[] { '-', '+' }, StringSplitOptions.RemoveEmptyEntries);
            if (versions.Length > 2)
            {
                throw new ArgumentException(expectedFormatMessage, nameof(versionRangeExpression));
            }

            if (int.TryParse(versions.First(), out var from) == false)
            {
                throw new ArgumentException($"{versions.First()} is not a number. {expectedFormatMessage}", nameof(versionRangeExpression));
            }

            var to = int.MaxValue;
            if (versions.Length == 1)
            {
                return new VersionRange(from, to);
            }

            if (int.TryParse(versions.Last(), out to) == false)
            {
                throw new ArgumentException($"{versions.Last()} is not a number. {expectedFormatMessage}", nameof(versionRangeExpression));
            }

            return new VersionRange(from, to);
        }

        public bool IsInRange(int version)
        {
            return version >= From &&
                   version <= To;
        }
    }
}