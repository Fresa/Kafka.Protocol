using System.Data;
using System.Text;

namespace Kafka.Protocol.Generator.Helpers.Extensions
{
    internal static class BufferExtensions
    {
        internal static bool CurrentSequenceIs(this IBuffer<char> buffer, string comparer)
        {
            var currentSequence = "";
            var originalPosition = buffer.Position;
            do
            {
                currentSequence += buffer.Current;
            } while (
                comparer != currentSequence &&
                comparer.Length > currentSequence.Length &&
                buffer.MoveToNext());

            buffer.MoveBack(buffer.Position - originalPosition);
            return comparer == currentSequence;
        }

        internal static void MoveBack<T>(this IBuffer<T> buffer, int times)
        {
            while (times-- > 0 && buffer.MoveToPrevious())
            {
            }
        }

        internal static void MoveForward<T>(this IBuffer<T> buffer, int times)
        {
            while (times-- > 0 && buffer.MoveToNext())
            {
            }
        }

        internal static bool HasNext<T>(this IBuffer<T> buffer)
        {
            return buffer.Position < buffer.Items.Length - 1;
        }

        internal static SyntaxErrorException CreateSyntaxError(
            this IBuffer<char> buffer,
            string message)
        {
            var rows = string
                .Concat(buffer.Items)
                .Split('\n');

            var position = buffer.Position;

            var exceptionMessage = new StringBuilder();
            exceptionMessage.AppendLine();
            foreach (var row in rows)
            {
                exceptionMessage.AppendLine(row);

                if (position >= 0 && 
                    position < row.Length)
                {
                    exceptionMessage.Append(new string(' ', position - 1));
                    exceptionMessage.AppendLine($"^- (POS {buffer.Position}) {message}");
                }

                position -= row.Length - 1;
            }

            return new SyntaxErrorException(exceptionMessage.ToString());
        }

        internal static T PeekBehind<T>(this IBuffer<T> buffer)
        {
            return buffer.Items[buffer.Position - 1];
        }

        internal static T Peek<T>(this IBuffer<T> buffer)
        {
            return buffer.Items[buffer.Position + 1];
        }
    }
}