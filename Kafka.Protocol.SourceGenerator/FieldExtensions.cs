using System.Reflection.Metadata.Ecma335;
using System.Threading;
using Kafka.Protocol.Generator.Helpers;
using Kafka.Protocol.Generator.Helpers.Definitions;
using Kafka.Protocol.Generator.Helpers.Extensions;

namespace Kafka.Protocol.SourceGenerator;

internal static class FieldExtensions
{
    internal static string GenerateSizeOf(
        this List<Generator.Helpers.Definitions.Messages.Field> messageFields) =>
        string.Join(" +", messageFields.Aggregate("",
            (expression, messageField) =>
            {
                var versionRange = VersionRange.Parse(messageField.Versions);
                if (messageField.TaggedVersions != null)
                {
                    var taggedVersionRange =
                        VersionRange.Parse(messageField.TaggedVersions);
                    versionRange = versionRange.Except(taggedVersionRange);
                    if (versionRange.None)
                    {
                        return string.Empty;
                    }
                }

                var isFlexibleVersionExpression =
                    messageField.FlexibleVersions == null
                        ? "IsFlexibleVersion"
                        : VersionRange.Parse(messageField.FlexibleVersions)
                            .GetExpression("Version");
                var propertyName = messageField.GetPropertyName();

                return $"""
                          {expression}{(expression == string.Empty ? "" : " +")}
                          {(versionRange.Full ? "" : $"({versionRange.GetExpression("Version")} ? ")}
                          {propertyName}.GetSize({isFlexibleVersionExpression})
                          {(versionRange.Full ? "" : ": 0)")}
                        """;
            }));

    internal static string GenerateReadFields(
        this List<Generator.Helpers.Definitions.Messages.Field> messageFields) =>
        messageFields.Aggregate("", (expression, field) =>
            $"""
             {expression}
             {field.GenerateReadField()}
             """);

    internal static string GenerateReadField(this Generator.Helpers.Definitions.Messages.Field messageField)
    {
        var versionRange = VersionRange.Parse(messageField.Versions);
        if (messageField.TaggedVersions != null)
        {
            var taggedVersionRange = VersionRange.Parse(messageField.TaggedVersions);
            versionRange = versionRange.Except(taggedVersionRange);
        }

        return versionRange.None
            ? string.Empty
            : messageField.GenerateRead(versionRange);
    }

    internal static string GenerateRead(this Generator.Helpers.Definitions.Messages.Field messageField, VersionRange versionRange)
    {
        if (versionRange.None)
            return string.Empty;
        var parentFieldTypeName = messageField.Parent?.GetFullTypeNameWithoutArrayCharacters() ?? "";
        var fieldName = messageField.GetFieldName(parentFieldTypeName);
        var fieldTypeName = messageField.GetTypeName();
        var fieldTypeNameWithoutArrayCharacters = messageField.GetFullTypeNameWithoutArrayCharacters();
        var isFlexibleVersionExpression = messageField.FlexibleVersions == null ?
            "instance.IsFlexibleVersion" :
            VersionRange.Parse(messageField.FlexibleVersions).GetExpression("version");
        return
            $"""
               {(versionRange.Full ? "" : $"if ({versionRange.GetExpression("instance.Version")})")}
               instance.{fieldName} = 
               {(messageField.Fields is null ? WithoutFields() : WithFields())}
             """;

        string WithoutFields() =>
            $"""
             await {fieldTypeName}
                 .FromReaderAsync(
             {(messageField.IsArray() ?
                 messageField.IsPrimitiveType() ?
                     $"""
                      reader, 
                      {isFlexibleVersionExpression}, 
                      () => {fieldTypeNameWithoutArrayCharacters}
                          .FromReaderAsync(
                              reader, 
                              instance.IsFlexibleVersion, 
                              cancellationToken), 
                      """ :
                     $"""
                       reader, 
                       {isFlexibleVersionExpression}, 
                       () => {fieldTypeNameWithoutArrayCharacters}
                           .FromReaderAsync(
                               instance.Version, 
                               reader, 
                               cancellationToken), 
                      """
                 : messageField.IsPrimitiveType() ?
                     $"""
                       reader, 
                       {isFlexibleVersionExpression}, 
                      """ :
                     """
                         instance.Version, 
                         reader, 
                     """)}
                     cancellationToken)
                 .ConfigureAwait(false);
             """;

        string WithFields()
        {
            var mapKeyField = messageField.Fields.FirstOrDefault(field => field.MapKey);
            return $"""
                    await {fieldTypeName}
                       .FromReaderAsync(
                    {(messageField.IsArray() ?
                        mapKeyField is null ?
                            $"""
                               reader, 
                               {isFlexibleVersionExpression}, 
                               () => {fieldTypeNameWithoutArrayCharacters}
                                   .FromReaderAsync(
                                       instance.Version, 
                                       reader, 
                                       cancellationToken), 
                             """ :
                            $"""
                                reader,
                                {isFlexibleVersionExpression}, 
                                () => {fieldTypeNameWithoutArrayCharacters}
                                    .FromReaderAsync(
                                       instance.Version,
                                       reader,
                                       cancellationToken), 
                                   field => field.{mapKeyField.GetName()}, 
                             """ :
                        messageField.IsNullable() ?
                            $"""
                             reader,
                             {isFlexibleVersionExpression}, 
                             () => {fieldTypeNameWithoutArrayCharacters}
                                .FromReaderAsync(
                                    instance.Version,
                                    reader,
                                    cancellationToken), 
                            """ : 
                            """
                              instance.Version,
                              reader,
                            """)}
                           cancellationToken)
                       .ConfigureAwait(false);
                    """;
        }
    }

    internal static string GenerateWriteTos(
        this List<Generator.Helpers.Definitions.Messages.Field>
            messageFields) =>
        messageFields.Aggregate("", (expression, field) =>
            $"""
             {expression}
             {field.GenerateWriteTo()}
             """);

    internal static string GenerateWriteTo(this Generator.Helpers.Definitions.Messages.Field messageField)
    {
        var versionRange = VersionRange.Parse(messageField.Versions);
        if (messageField.TaggedVersions != null)
        {
            var taggedVersionRange = VersionRange.Parse(messageField.TaggedVersions);
            versionRange = versionRange.Except(taggedVersionRange);
            if (versionRange.None)
            {
                return string.Empty;
            }
        }

        var isFlexibleVersionExpression = messageField.FlexibleVersions == null ?
            "IsFlexibleVersion" :
            VersionRange.Parse(messageField.FlexibleVersions).GetExpression("Version");
        var propertyName = messageField.GetPropertyName();
        return $"""
                {(versionRange.Full ?
                     "" :
                     $"if ({versionRange.GetExpression("Version")})")}
                await {propertyName}
                   .WriteToAsync(
                       writer, 
                       {isFlexibleVersionExpression}, 
                       cancellationToken)
                   .ConfigureAwait(false);
                """;
    }

    internal static string GenerateFields(
        this List<Generator.Helpers.Definitions.Messages.Field> fields,
        string className) =>
        fields.AggregateToString(field =>
            field.GenerateField(className));

    internal static string GenerateField(
        this Generator.Helpers.Definitions.Messages.Field field, 
        string className)
    {
        var propertyTypeName = field.GetFullTypeName();
        var fieldTypeNameWithoutArrayCharacters = field.GetFullTypeNameWithoutArrayCharacters();
        var fieldTypeName = field.GetNullableFullTypeName();
        var propertyName = field.GetPropertyName();
        var fieldName = field.GetFieldName(className);
        var flexibleVersionRange = field.FlexibleVersions == null ?
            VersionRange.Parse(field.Message.FlexibleVersions) :
            VersionRange.Parse(field.FlexibleVersions);
        var versionRange =
            new Lazy<VersionRange>(() => VersionRange.Parse(field.Versions));
        var nullableVersionRange = new Lazy<VersionRange>(() =>
            VersionRange.Parse(
                field.NullableVersions ??
                throw new InvalidOperationException(
                    "field is missing nullable versions")));
        var fieldDocumentation = GenerateFieldDocumentation();

        var fieldBody = 
            $$"""
                {{(field.Tag.HasValue ?
                    $"private bool {propertyName}IsSet;" : "")}}
                    private {{propertyTypeName}} {{propertyName}} =
                    {{(field.Default is not null ?
                        $"new {propertyTypeName}({(field.Default == "" ? "string.Empty" : field.Default)});" :
                        field.IsDictionary() ?
                            $"{propertyTypeName}.Default;" :
                            field.IsArray() ?
                                $"Array.Empty<{fieldTypeNameWithoutArrayCharacters}>();" :
                                field.IsPrimitiveType() ?
                                    $"{propertyTypeName}.Default;" :
                                    "default!;")}}
                                  
                {{fieldDocumentation}}
                  
                public {{fieldTypeName}} {{fieldName}}  
                {
                    get => {{propertyName}};
                    private set  
                    {
                    	{{(!field.Ignorable &&
                           !versionRange.Value.Full ?
                        $$"""
                            if ({{versionRange.Value.GetExpression("Version")}} == false) 
                                throw new UnsupportedVersionException($"{{fieldName}} does not support version {Version} and has been defined as not ignorable. Supported versions: {{field.Versions}}"); 
                        """ : "")}}
             
                        {{(field.IsNullable() &&
                            !nullableVersionRange.Value.Full ?
                        $$"""
                            if ({{nullableVersionRange.Value.GetExpression("Version")}} == false &&
                                value == null) 
                                throw new UnsupportedVersionException($"{{fieldName}} does not support null for version {Version}. Supported versions for null value: {{field.NullableVersions}}");
                            """ : "")}}
             
                        {{propertyName}} = value;
                        {{field.Tag.HasValue.IfTrue($"{propertyName}IsSet = true;")}}
                    }
                }
               
                {{fieldDocumentation}}
            """;
        if (field.Fields is null)
        {
            var fieldTypeArgumentName = field.GetName().FirstCharacterToLowerCase();
            return
                $$"""
                    {{fieldBody}}
                    public {{className}} With{{fieldName}}({{fieldTypeName}} {{fieldTypeArgumentName}}) 
                    {
                        {{fieldName}} = {{fieldTypeArgumentName}};
                        return this;
                    }
                  """;
        }

        return
            $$"""
              {{fieldBody}}
              {{(field.TryGetMapKeyField(out var mapKeyField) ?
                  $$"""
                        public {{className}} With{{fieldName}}(params Func<{{fieldTypeNameWithoutArrayCharacters}}, {{fieldTypeNameWithoutArrayCharacters}}>[] createFields) 
                        {
                            {{fieldName}} = createFields
                                .Select(createField => createField(new {{fieldTypeNameWithoutArrayCharacters}}(Version)))
                                .ToDictionary(field => {{(mapKeyField.IsNullable() ? $"({mapKeyField.GetFullTypeName()})" : "")}}field.{{mapKeyField.GetName()}});
                            return this;
                        } 
                       
                        public delegate {{fieldTypeNameWithoutArrayCharacters}} Create{{fieldTypeNameWithoutArrayCharacters}}({{fieldTypeNameWithoutArrayCharacters}} field);
                       
                        {{fieldDocumentation}}
                        public {{className}} With{{fieldName}}(IEnumerable<Create{{fieldTypeNameWithoutArrayCharacters}}> createFields) 
                        {
                            {{fieldName}} = createFields
                                .Select(createField => createField(new {{fieldTypeNameWithoutArrayCharacters}}(Version)))
                                .ToDictionary(field => {{(mapKeyField.IsNullable() ? $"({mapKeyField.GetFullTypeName()})" : "")}}field.{{mapKeyField.GetName()}});
                            return this;
                        } 
                    """ : field.IsArray() ?
                      $$"""
                            public {{className}} With{{fieldName}}(params Func<{{fieldTypeNameWithoutArrayCharacters}}, {{fieldTypeNameWithoutArrayCharacters}}>[] createFields) 
                            {
                                    {{fieldName}} = createFields
                                        .Select(createField => createField(new {{fieldTypeNameWithoutArrayCharacters}}(Version)))
                                        .ToArray();
                                    return this;
                            } 
                        
                            public delegate {{fieldTypeNameWithoutArrayCharacters}} Create{{fieldTypeNameWithoutArrayCharacters}}({{fieldTypeNameWithoutArrayCharacters}} field);
                        
                            {{fieldDocumentation}}
                            public {{className}} With{{fieldName}}(IEnumerable<Create{{fieldTypeNameWithoutArrayCharacters}}> createFields) 
                            {
                                {{fieldName}} = createFields
                                    .Select(createField => createField(new {{fieldTypeNameWithoutArrayCharacters}}(Version)))
                                    .ToArray();
                                return this;
                            } 
                        """ :
                      $$"""
                           public {{className}} With{{fieldName}}(Func<{{fieldTypeName}}, {{fieldTypeName}}> createField) 
                           {
                              {{fieldName}} = createField(new {{fieldTypeNameWithoutArrayCharacters}}(Version));
                              return this;
                           }
                        """)}}

              public class {{fieldTypeNameWithoutArrayCharacters}} : ISerialize 
              {
                  internal {{fieldTypeNameWithoutArrayCharacters}}(Int16 version) 
                  {
                      Version = version;
                      IsFlexibleVersion = {{flexibleVersionRange.GetExpression("version")}};
                  } 
              
                  internal Int16 Version { get; }
                  internal bool IsFlexibleVersion { get; }
              
                  {{Tag.GenerateCreateTagSection(field.GetTaggedFields().ToArray())}} 
              
                  int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                  internal int GetSize(bool _) =>
                      {{field.Fields.GenerateSizeOf()}} +
                      {{Tag.GenerateSizeOf()}};
              
                  internal static async ValueTask<{{fieldTypeNameWithoutArrayCharacters}}> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default) 
                  {
                      var instance = new {{fieldTypeNameWithoutArrayCharacters}}(version);
                      {{field.Fields.GenerateReadFields()}}
               
                      {{Tag.GenerateReadTags(field.GetTaggedFields(), fieldTypeNameWithoutArrayCharacters)}}
               
                      return instance; 
                   } 
               
                   ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => WriteToAsync(writer, asCompact, cancellationToken);
                   internal async ValueTask WriteToAsync(Stream writer, bool _, CancellationToken cancellationToken = default) 
                   {
                      {{field.Fields.GenerateWriteTos()}}
               
                      {{Tag.GenerateWriteTags()}}
                   } 
               
                   {{field.Fields.GenerateFields(fieldTypeNameWithoutArrayCharacters)}}			
               }
              """;

        string GenerateFieldDocumentation() =>
            Documentation.Generate(
                field.About,
                $"Versions: {field.Versions}",
                field.Default is null
                    ? string.Empty
                    : $"Default: {(field.Default == string.Empty ? "Empty string" : field.Default)}");
    }
}