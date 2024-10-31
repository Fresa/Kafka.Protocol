using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Octokit;

namespace Kafka.Protocol.MessageDefinitionsDownloader
{
    partial class Program
    {
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

            var outputPath = new Uri(new Uri(repositoryPath), "Kafka.Protocol.MessageDefinitionsDownloader/MessageDefinitions/");
            var client = new KafkaGithubRepositoryClient();
            var latestReleaseTag = await client.GetLatestReleaseTagAsync()
                .ConfigureAwait(false);

            var readmePath = new Uri(new Uri(repositoryPath), "README.md");
            var updated = await UpdateKafkaReleaseTagInReadmeIfNewerReleaseAsync(readmePath,
                    latestReleaseTag)
                .ConfigureAwait(false);
            if (!updated)
            {
                return;
            }

            Console.WriteLine($"Writing files to '{outputPath}'");
            await client.GetMessagesAndWriteToPathAsync(outputPath, latestReleaseTag)
                .ConfigureAwait(false);
            Console.WriteLine("Done");
        }

        private static async Task<bool> UpdateKafkaReleaseTagInReadmeIfNewerReleaseAsync(Uri readmePath, RepositoryTag releaseTag)
        {
            var readmeContent = await File.ReadAllTextAsync(readmePath.AbsolutePath)
                .ConfigureAwait(false);
            var currentVersionTextMatch = GetReleaseTagRegEx().Match(readmeContent);
            if (!currentVersionTextMatch.Success)
            {
                throw new InvalidOperationException(
                    $"Expected to find {GetReleaseTagRegEx()} in {readmePath}");
            }

            var newVersion = releaseTag.Name.Trim();
            var newVersionText = $"Kafka version: **{newVersion}**";
            if (!GetReleaseTagRegEx().IsMatch(newVersionText))
            {
                throw new InvalidOperationException(
                    $"Expected the new version text '{newVersionText}' to match {GetReleaseTagRegEx()}, this is an implementation error");
            }

            var currentVersion = currentVersionTextMatch.Value
                .Replace("Kafka version:", "")
                .Trim()
                .Trim('*');
            switch (string.CompareOrdinal(newVersion, currentVersion))
            {
                case 0:
                    Console.WriteLine($"Proposed version {newVersion} is the same as current version");
                    return false;
                case < 0:
                    Console.WriteLine($"Proposed version {newVersion} is older than current version {currentVersion}");
                    return false;
            }

            Console.WriteLine($"Updating {readmePath} from Kafka version {currentVersion} to {newVersion}");
            var newReadmeContent = GetReleaseTagRegEx().Replace(readmeContent,
                newVersionText);
            await File.WriteAllTextAsync(readmePath.AbsolutePath, newReadmeContent)
                .ConfigureAwait(false);
            return true;
        }

        [GeneratedRegex(@"^Kafka version: \*\*\d+\.\d+\.\d+\*\*\r?$", RegexOptions.Multiline)]
        private static partial Regex GetReleaseTagRegEx();
    }
}
