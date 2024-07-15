using Kafka.Protocol.SourceGenerator.Definitions;
using Kafka.Protocol.SourceGenerator.Definitions.Messages;

namespace Kafka.Protocol.SourceGenerator;

internal static class CommonStructExtensions
{
    internal static string GenerateCommonStructs(
        this List<CommonStruct>? commonStructs)
    {
        return commonStructs?.Aggregate("", (expression, commonStruct) =>
            $"""
             {expression}
             {commonStruct.GenerateCommonStruct()}
             """) ?? string.Empty;
    }

    private static string GenerateCommonStruct(this CommonStruct commonStruct)
    {
        var versionRange = VersionRange.Parse(commonStruct.Versions);
        var flexibleVersionRange = VersionRange.Parse(commonStruct.Message.FlexibleVersions);
        return
            $$"""
                public class {{commonStruct.Name}} : ISerialize 
                {
                    internal {{commonStruct.Name}}(Int16 version) 
                    {
                        {{versionRange.Full.IfFalse(
                            $$"""
                              if (versionRange.GetExpression("version") == false) 
                                  throw new UnsupportedVersionException($"{{commonStruct.Name}} does not support version {version}. Valid versions are: {{commonStruct.Versions}}");
                              """)}}
                             
                        Version = version;
                        IsFlexibleVersion = {{flexibleVersionRange.GetExpression("version")}};
                    }
                        
                    internal Int16 Version { get; }
                    internal bool IsFlexibleVersion { get; }
                    
                    {{Tag.GenerateCreateTagSection(commonStruct.GetTaggedFields().ToArray())}} 
                    
                    int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                    internal int GetSize(bool _) =>
                        {{commonStruct.Fields.GenerateSizeOf()}} +
                        {{Tag.GenerateSizeOf()}};
                    
                    internal static async ValueTask<{{commonStruct.Name}}> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default) 
                    {
                        var instance = new {{commonStruct.Name}}(version);
                        
                        {{commonStruct.Fields.GenerateReadFields()}}
              
                        {{Tag.GenerateReadTags(commonStruct.GetTaggedFields(), commonStruct.Name)}}
                    
                        return instance;
                    } 
                    
                    ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                    internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default) 
                    {
                        {{commonStruct.Fields.GenerateWriteTos()}}
              
                        {{Tag.GenerateWriteTags()}}
                    } 
              
                    {{commonStruct.Fields.GenerateFields(commonStruct.Name)}}
                }
              """;
    }
}
