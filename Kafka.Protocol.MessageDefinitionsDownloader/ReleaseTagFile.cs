using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Octokit;
using Octokit.Internal;

namespace Kafka.Protocol.MessageDefinitionsDownloader;

internal sealed class ReleaseTagFile
{
    private static readonly SimpleJsonSerializer Serializer = new();
    private RepositoryTag? _repositoryTag;
    private readonly string _path;

    private ReleaseTagFile(string path, RepositoryTag? repositoryTag = null)
    {
        _path = path;
        _repositoryTag = repositoryTag;
    }

    internal static async Task<ReleaseTagFile> ReadAsync(string path, CancellationToken cancellation = default)
    {
        var releaseTagExists = File.Exists(path);
        if (!releaseTagExists)
        {
            return new ReleaseTagFile(path);
        }

        var currentReleaseTagContent = await File
            .ReadAllTextAsync(path, cancellation)
            .ConfigureAwait(false);
        var currentKafkaReleaseTag =
            Serializer.Deserialize<RepositoryTag>(currentReleaseTagContent);
        return new ReleaseTagFile(path, currentKafkaReleaseTag);
    }

    internal bool UpdateIfNewer(RepositoryTag releaseTag)
    {
        if (_repositoryTag is null)
        {
            Console.WriteLine(
                "No current release exist, setting proposed version {releaseTag.Name}");
            _repositoryTag = releaseTag;
            return true;
        }
        
        switch (string.CompareOrdinal(releaseTag.Name, _repositoryTag.Name))
        {
            case 0:
                Console.WriteLine(
                    $"Proposed version {releaseTag.Name} is the same as current version");
                return false;
            case < 0:
                Console.WriteLine(
                    $"Proposed version {releaseTag.Name} is older than current version {_repositoryTag.Name}, keeping current version");
                return false;
            default:
                Console.WriteLine(
                    $"Proposed version {releaseTag.Name} is newer than current version {_repositoryTag.Name}, setting proposed version");
                break;
        }

        _repositoryTag = releaseTag;
        return true;
    }

    internal async Task SaveAsync(CancellationToken cancellation = default)
    {
        var currentReleaseTagContent = Serializer.Serialize(_repositoryTag);
        await File.WriteAllTextAsync(_path,
                currentReleaseTagContent,
                cancellation)
            .ConfigureAwait(false);
    }
}