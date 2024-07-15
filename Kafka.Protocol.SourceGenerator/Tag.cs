using System.Linq.Expressions;
using Kafka.Protocol.SourceGenerator.Definitions;
using Kafka.Protocol.SourceGenerator.Definitions.Messages;

namespace Kafka.Protocol.SourceGenerator;

internal static class Tag
{
    internal static string GenerateCreateTagSection(Field[] taggedFields)
    {
        return taggedFields.Length == 0
            ? """
                private Tags.TagSection CreateTagSection()
                {
                    return new Tags.TagSection();
                }	
              """
            : $$"""
                private Tags.TagSection CreateTagSection()
                {
                    var tags = new List<Tags.TaggedField>();
                    {{taggedFields.AggregateToString(GenerateAddTag)}}
                    return new Tags.TagSection(tags.ToArray());
                }	
                """;
    }

    private static string GenerateAddTag(Field taggedField)
    {
        var propertyName = taggedField.GetPropertyName();
        var versionRange = taggedField.TaggedVersions == null
            ? VersionRange.Parse(taggedField.Versions)
            : VersionRange.Parse(taggedField.TaggedVersions);
        return $$"""
                    if ({{(versionRange.Full ? "" : versionRange.GetExpression("Version") + " && ")}}{{propertyName}}IsSet) 
                    {
                        tags.Add(new Tags.TaggedField 
                        {
                            Tag = {{taggedField.Tag}},
                            Field = {{propertyName}} 
                        });
                    }
                 """;
    }

    internal static string GenerateSizeOf() =>
        $"""
         (IsFlexibleVersion ?
           CreateTagSection().GetSize() : 0)
         """;

    internal static string GenerateReadTags(
        IEnumerable<Field>
            taggedFields, string parentType) =>
        $$"""
            if (instance.IsFlexibleVersion)
            {
                var tagSection = await Tags.TagSection.FromReaderAsync(reader, cancellationToken).ConfigureAwait(false);
                await foreach (var tag in tagSection.WithCancellation(cancellationToken).ConfigureAwait(false)) 
                {
                    switch (tag.Tag) 
                    {
                        {{taggedFields.GenerateReadTagCases()}}
                        default:
                	        throw new InvalidOperationException($"Tag '{tag.Tag}' for {{parentType}} is unknown");
                    }
                }
            }
          """;

    private static string GenerateReadTagCases(
        this IEnumerable<Field> taggedFields) =>
        taggedFields.AggregateToString(field => field.GenerateReadTagCase());

    private static string GenerateReadTagCase(this Field taggedField)
    {
        var propertyName = taggedField.GetPropertyName();
        var parentFieldTypeName =
            taggedField.Parent?.GetFullTypeNameWithoutArrayCharacters() ?? "";
        var fieldName = taggedField.GetFieldName(parentFieldTypeName);

        return
            $$"""
                case {{taggedField.Tag}}:
                    {{taggedField.GenerateReadTag()}}
                    
                    {
                        var size = instance.{{propertyName}}.GetSize(true);
                        if (size != tag.Length)
                            throw new CorruptMessageException($"Tagged field {{fieldName}} read length {tag.Length} but had actual length of {size}");
                    }
                break;
              """;
    }

    private static string GenerateReadTag(this Field messageField)
    {
        var parentFieldTypeName = messageField.Parent?.GetFullTypeNameWithoutArrayCharacters() ?? "";
        var fieldName = messageField.GetFieldName(parentFieldTypeName);

        var versionRange = messageField.TaggedVersions == null ?
            VersionRange.Parse(messageField.Versions) :
            VersionRange.Parse(messageField.TaggedVersions);

        if (versionRange.None)
        {
            return string.Empty;
        }

        return
            $"""
               {messageField.GenerateRead(versionRange)}
               {(versionRange.Full ? "" :
               $$"""
                 else
                     throw new InvalidOperationException($"Field {{fieldName}} is not supported for version {instance.Version}");
                 """)}
             """;
    }

    internal static string GenerateWriteTags() =>
        """
        if (IsFlexibleVersion)
        {
            await CreateTagSection()
                .WriteToAsync(writer, cancellationToken)
                .ConfigureAwait(false);
        }
        """;
}