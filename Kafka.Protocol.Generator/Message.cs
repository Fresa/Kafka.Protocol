using System.Collections.Generic;
using Kafka.Protocol.Generator.BackusNaurForm;

namespace Kafka.Protocol.Generator
{
    internal class Message
    {
        public Message(int key, string name)
        {
            Key = key;
            Name = name;
        }

        public int Key { get; }
        public string Name { get; }

        private readonly Dictionary<int, Method> _requests = new Dictionary<int, Method>();
        public IReadOnlyDictionary<int, Method> Requests => _requests;

        internal void Add(int version, Method method)
        {
            _requests.Add(version, method);
        }

    }
}