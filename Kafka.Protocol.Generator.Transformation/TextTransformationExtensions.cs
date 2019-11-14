using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TextTemplating;

namespace Kafka.Protocol.Generator.Transformation
{
    public static class TextTransformationExtensions
    {
        private const string TabCharacter = "\t";

        public static void WriteNewLine(this TextTransformation textTransformation, int count = 1)
        {
            for (var i = 0; i < count; i++)
            {
                textTransformation.WriteLine(string.Empty);
            }
        }

        public static void Indent(this TextTransformation textTransformation)
        {
            textTransformation.PushIndent(TabCharacter);
        }

        public static void Dedent(this TextTransformation textTransformation)
        {
            textTransformation.PopIndent();
        }

        public static void Tab(this TextTransformation textTransformation, Action action)
        {
            Indent(textTransformation);
            action();
            Dedent(textTransformation);
        }

        public static void Block(this TextTransformation textTransformation, Action action)
        {
            WriteNewLine(textTransformation);
            textTransformation.WriteLine("{");
            Tab(textTransformation, action);
            WriteNewLine(textTransformation);
            textTransformation.Write("}");
        }

        public static void PrintOnNewRowForEach<TValue>(this TextTransformation textTransformation, IEnumerable<TValue> iterator, ActionDelegateWithIndexAndLength<TValue> action)
        {
            var list = iterator.ToList();
            var count = list.Count;
            foreach (var pair in list.WithIndex())
            {
                if (pair.Key > 0)
                {
                    WriteNewLine(textTransformation);
                }

                action(pair.Value, pair.Key, count);
            }
        }

        public static void PrintOnNewRowForEach<TValue>(this TextTransformation textTransformation, IEnumerable<TValue> iterator, Action<TValue> action)
        {
            PrintOnNewRowForEach(textTransformation, iterator, (value, index, length) => action(value));
        }
    }

    public delegate void ActionDelegateWithIndexAndLength<in T>(T value, int index, int length);
}