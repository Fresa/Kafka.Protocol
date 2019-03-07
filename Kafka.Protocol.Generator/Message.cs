using System.Collections.Generic;
using System.Linq;
using Kafka.Protocol.Generator.BackusNaurForm;

namespace Kafka.Protocol.Generator
{
    internal class Message
    {
        internal Message(int key, string name, List<Method> methods)
        {
            Key = key;
            Name = name;

            Methods = methods;
        }

        public int Key { get; }
        public string Name { get; }
        public List<Method> Methods { get; }
    }
}