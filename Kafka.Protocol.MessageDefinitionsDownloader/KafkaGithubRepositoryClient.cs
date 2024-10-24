using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        private const string RepositoryOwner = "apache";
        private const string RepositoryName = "kafka";
        private readonly GitHubClient _client = new(
                    new ProductHeaderValue("Kafka.Protocol"));

        public async Task GetMessagesAndWriteToPathAsync(string path, CancellationToken cancellationToken = default)
        {
            var pathUri = new Uri(path);
            var latestReleaseTag = await GetLatestReleaseTagAsync(cancellationToken)
                .ConfigureAwait(false);
            var files = await GetMessageFilesAsync(latestReleaseTag);

            foreach (var file in new DirectoryInfo(pathUri.AbsolutePath).GetFiles())
            {
                file.Delete();
            }
            using var fileClient = new HttpClient();

            var releaseTagFileUri = new Uri(pathUri, "release_tag.md");
            var releaseTagFileStream = new FileStream(releaseTagFileUri.AbsolutePath,
                FileMode.Create, FileAccess.Write);
            await using (releaseTagFileStream.ConfigureAwait(false))
            {
                await releaseTagFileStream.WriteAsync(
                        Encoding.UTF8.GetBytes(latestReleaseTag.Name),
                        cancellationToken)
                    .ConfigureAwait(false);
            }

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

        [GeneratedRegex(@"^\d+.\d+.\d+$")]
        private partial Regex GetReleaseTagRegEx();

        private async Task<RepositoryTag> GetLatestReleaseTagAsync(
            CancellationToken _)
        {
            var tags = await _client.Repository.GetAllTags(
                    RepositoryOwner,
                    RepositoryName)
                .ConfigureAwait(false);
            return tags.First(tag => GetReleaseTagRegEx().IsMatch(tag.Name));
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