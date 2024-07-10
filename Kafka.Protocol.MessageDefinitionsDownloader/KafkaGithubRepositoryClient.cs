using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Kafka.Protocol.SourceGenerator.Definitions.Messages;
using Newtonsoft.Json;
using Octokit;
using ProductHeaderValue = Octokit.ProductHeaderValue;

namespace Kafka.Protocol.MessageDefinitionsDownloader
{
    public class KafkaGithubRepositoryClient
    {
        private readonly GitHubClient _client = new GitHubClient(
                    new ProductHeaderValue("Kafka.Protocol"));

        public async Task<IEnumerable<Message>> GetMessagesAsync()
        {
            var files = await GetMessageFilesAsync()
                .ConfigureAwait(false);

            var fileClient = new HttpClient();

            var messagesContent = await Task.WhenAll(files
                .Select(async repositoryContent =>
                    await
                        (await fileClient
                            .GetAsync(repositoryContent.DownloadUrl)
                            .ConfigureAwait(false))
                        .Content
                        .ReadAsStringAsync()
                        .ConfigureAwait(false)).ToArray());

            return messagesContent
                .Select(
                    JsonConvert.DeserializeObject<Message>);
        }

        public async Task GetMessagesAndWriteToPathAsync(string path)
        {
            var files = await GetMessageFilesAsync();

            foreach (var file in new DirectoryInfo(path).GetFiles())
            {
                file.Delete();
            }
            
            await Task.WhenAll(files
                .Select(async repositoryContent =>
                        await new WebClient()
                            .DownloadFileTaskAsync(
                                repositoryContent.DownloadUrl,
                                $"{path}\\{repositoryContent.Name}")
                            .ConfigureAwait(false)));
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