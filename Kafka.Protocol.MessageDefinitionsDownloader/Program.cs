using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Octokit;
using Octokit.Internal;

namespace Kafka.Protocol.MessageDefinitionsDownloader
{
    class Program
    {
        private const string ReleaseTagFileName = "KafkaReleaseTag.json";
        private const string ReadmeFileName = "README.md";
        private const string MessageDefinitionsPath =
            "Kafka.Protocol.MessageDefinitionsDownloader/MessageDefinitions/";
        
        private static async Task Main(string[] args)
        {
            var repositoryPath = Environment.CurrentDirectory;
            if (args.Any())
            {
                repositoryPath = args.First();
                if (!Directory.Exists(repositoryPath))
                {
                    await Console.Error.WriteLineAsync($"'{repositoryPath}' is not a valid directory")
                        .ConfigureAwait(false);
                    return;
                }
            }

            var githubClient = CreateGithubClient();
            var latestReleaseTag = await githubClient.GetLatestReleaseTagAsync()
                .ConfigureAwait(false);
            var kafkaReleaseTagFilePath =
                Path.Combine(repositoryPath, ReleaseTagFileName);
            var releaseTagFile = await ReleaseTagFile.ReadAsync(kafkaReleaseTagFilePath)
                .ConfigureAwait(false);
            if (!releaseTagFile.UpdateIfNewer(latestReleaseTag))
            {
                return;
            }
            await releaseTagFile.SaveAsync()
                .ConfigureAwait(false);

            var outputPath = Path.Combine(repositoryPath, MessageDefinitionsPath);
            DeleteExistingMessageDefinitions(outputPath);
            Console.WriteLine($"Downloading and writing specifications to '{outputPath}'");
            await githubClient.GetMessagesAndWriteToPathAsync(outputPath, latestReleaseTag)
                .ConfigureAwait(false);

            var readmePath = Path.Combine(repositoryPath, ReadmeFileName);
            var readmeFile = await ReadmeFile.ReadAsync(readmePath)
                .ConfigureAwait(false);
            Console.WriteLine($"Updating {readmePath} with Kafka release information");
            readmeFile.UpdateKafkaRelease(latestReleaseTag);
            await readmeFile.SaveAsync()
                .ConfigureAwait(false);
        }

        private static KafkaGithubRepositoryClient CreateGithubClient()
        {
            var githubToken =
                Environment.GetEnvironmentVariable("GITHUB_TOKEN");
            var githubCredentials = new InMemoryCredentialStore(
                githubToken is null
                    ? Credentials.Anonymous
                    : new Credentials(githubToken));
            return new KafkaGithubRepositoryClient(githubCredentials);
        }

        private static void DeleteExistingMessageDefinitions(string outputPath)
        {
            Console.WriteLine($"Deleting existing specifications from '{outputPath}'");
            foreach (var file in new DirectoryInfo(outputPath).GetFiles())
            {
                file.Delete();
            }
        }
    }
}