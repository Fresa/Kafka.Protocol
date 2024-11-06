using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Octokit;

namespace Kafka.Protocol.MessageDefinitionsDownloader;

internal partial class ReadmeFile
{
    private readonly string _path;
    private string _content;

    private ReadmeFile(string path, string content)
    {
        _path = path;
        _content = content;
    }

    internal static async Task<ReadmeFile> ReadAsync(string readmePath, CancellationToken cancellation = default)
    {
        var readmeContent = await File.ReadAllTextAsync(readmePath, cancellation)
            .ConfigureAwait(false);
        return new ReadmeFile(readmePath, readmeContent);
    }

    internal void UpdateKafkaRelease(RepositoryTag releaseTag)
    {
        var currentVersionTextMatch = GetReleaseTagRegEx().Match(_content);
        if (!currentVersionTextMatch.Success)
        {
            throw new InvalidOperationException(
                $"Expected to find {GetReleaseTagRegEx()} in {_path}");
        }

        var newVersion = releaseTag.Name.Trim();
        var newVersionText =
            $"Kafka version: [**{newVersion}**](https://github.com/{KafkaGithubRepositoryClient.RepositoryOwner}/{KafkaGithubRepositoryClient.RepositoryName}/releases/tag/{releaseTag.Name})";
        if (!GetReleaseTagRegEx().IsMatch(newVersionText))
        {
            throw new InvalidOperationException(
                $"Expected the new version text '{newVersionText}' to match {GetReleaseTagRegEx()}, this is an implementation error");
        }

        _content = GetReleaseTagRegEx().Replace(_content,
            newVersionText);
    }

    [GeneratedRegex(@"^Kafka version: .*\r?$", RegexOptions.Multiline)]
    private static partial Regex GetReleaseTagRegEx();

    internal Task SaveAsync(CancellationToken cancellation = default) => 
        File.WriteAllTextAsync(_path, _content, cancellation);
}