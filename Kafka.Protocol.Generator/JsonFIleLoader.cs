using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Kafka.Protocol.Generator
{
    public static class JsonFileLoader
    {
        public static IEnumerable<T> LoadFrom<T>(string path)
        {
            return Directory
                .EnumerateFiles(path, "*.json")
                .Select(File.ReadAllText)
                .Select(JsonConvert.DeserializeObject<T>);
        }
    }
}