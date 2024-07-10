using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
                    await Console.Error.WriteLineAsync($"'{path}' is not a valid directory")
                        .ConfigureAwait(false);
                    return;
                }
            }

            var client = new KafkaGithubRepositoryClient();
            Console.WriteLine($"Writing files to '{path}'");
            await client.GetMessagesAndWriteToPathAsync(path)
                .ConfigureAwait(false);
            Console.WriteLine("Done");
        }
    }
}
