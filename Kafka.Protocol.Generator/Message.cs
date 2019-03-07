using System.Collections.Generic;
using System.Linq;
using Kafka.Protocol.Generator.BackusNaurForm;

namespace Kafka.Protocol.Generator
{
    internal class Message
    {
        internal Message(int key, string name, IDictionary<int, Method> requests)
        {
            Key = key;
            Name = name;
            Requests = requests.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        public int Key { get; }
        public string Name { get; }
        public IReadOnlyDictionary<int, Method> Requests { get; }
    }
}