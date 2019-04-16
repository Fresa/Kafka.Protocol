using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Kafka.Protocol.Generator;

namespace Kafka.Protocol.MessageDefinitionsDownloader
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            var path = Environment.CurrentDirectory;
            if (args.Any())
            {
                path = args.First();
                if (!Directory.Exists(path))
                {
                    Console.Error.WriteLine($"'{path}' is not a valid directory");
                    return;
                }
            }

            var client = new KafkaGithubRepositoryClient();
            Console.WriteLine($"Writing files to '{path}'");
            await client.GetMessagesAndWriteToPathAsync(path);
            Console.WriteLine("Done");
        }
    }
}
