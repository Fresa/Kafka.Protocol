using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Octokit;
using FileMode = System.IO.FileMode;
using ProductHeaderValue = Octokit.ProductHeaderValue;

namespace Kafka.Protocol.MessageDefinitionsDownloader
{
    public class KafkaGithubRepositoryClient
    {
        private readonly GitHubClient _client = new(
                    new ProductHeaderValue("Kafka.Protocol"));

        public async Task GetMessagesAndWriteToPathAsync(string path, CancellationToken cancellationToken = default)
        {
            var pathUri = new Uri(path);
            var files = await GetMessageFilesAsync();

            foreach (var file in new DirectoryInfo(pathUri.AbsolutePath).GetFiles())
            {
                file.Delete();
            }
            using var fileClient = new HttpClient();

            await Task.WhenAll(files
                .Select(async repositoryContent =>
                {
                    var fileUri  =  new Uri(pathUri, repositoryContent.Name);
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
        
        private async Task<IEnumerable<RepositoryContent>> GetMessageFilesAsync()
        {
            var content = await _client
                .Repository
                .Content
                .GetAllContents(
                    "apache",
                    "kafka",
                    "clients/src/main/resources/common/message")
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