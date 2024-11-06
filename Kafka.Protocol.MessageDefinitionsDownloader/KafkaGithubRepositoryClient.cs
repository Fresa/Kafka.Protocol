using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Octokit;
using FileMode = System.IO.FileMode;
using ProductHeaderValue = Octokit.ProductHeaderValue;

namespace Kafka.Protocol.MessageDefinitionsDownloader
{
    public partial class KafkaGithubRepositoryClient
    {
        internal const string RepositoryOwner = "apache";
        internal const string RepositoryName = "kafka";
        private readonly GitHubClient _client = new(
                    new ProductHeaderValue("Kafka.Protocol"));

        public async Task GetMessagesAndWriteToPathAsync(Uri pathUri, RepositoryTag releaseTag, CancellationToken cancellationToken = default)
        {
            var files = await GetMessageFilesAsync(releaseTag);

            using var fileClient = new HttpClient();

            await Task.WhenAll(files
                .Select(async repositoryContent =>
                {
                    var fileUri = new Uri(pathUri, repositoryContent.Name);
                    var fileStream = new FileStream(fileUri.AbsolutePath,
                        FileMode.Create, FileAccess.Write);
                    await using (fileStream.ConfigureAwait(false))
                    {
                        var content = await
                            (await fileClient
                                .GetAsync(repositoryContent.DownloadUrl, cancellationToken)
                                .ConfigureAwait(false))
                            .Content
                            .ReadAsStreamAsync(cancellationToken)
                            .ConfigureAwait(false);
                        await content.CopyToAsync(fileStream, cancellationToken)
                            .ConfigureAwait(false);
                    }
                }));
        }

        [GeneratedRegex(@"^\d+\.\d+\.\d+$")]
        private partial Regex GetReleaseTagRegEx();

        internal async Task<RepositoryTag> GetLatestReleaseTagAsync()
        {
            Console.WriteLine($"Finding latest release matching {GetReleaseTagRegEx()}");
            var tags = await _client.Repository.GetAllTags(
                    RepositoryOwner,
                    RepositoryName)
                .ConfigureAwait(false);
            return tags.First(tag =>
            {
                var isMatch = GetReleaseTagRegEx().IsMatch(tag.Name);
                Console.WriteLine($"{tag.Name} -> {(isMatch ? "Match" : "No match")}");
                return isMatch;
            });
        }

        private async Task<IEnumerable<RepositoryContent>> GetMessageFilesAsync(RepositoryTag tag)
        {
            var content = await _client
                .Repository
                .Content
                .GetAllContentsByRef(
                    RepositoryOwner, 
                    RepositoryName,
                    "clients/src/main/resources/common/message",
                    tag.Name)
                .ConfigureAwait(false);

            var messages = content
                .Where(repositoryContent =>
                    repositoryContent
                        .Name
                        .EndsWith(".json"));

            return messages;
        }
    }
}