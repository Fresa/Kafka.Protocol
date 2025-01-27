using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Kafka.Protocol.SourceGenerator.Definitions;
using Kafka.Protocol.SourceGenerator.Definitions.Messages;
using Kafka.Protocol.SourceGenerator.Extensions;
using Kafka.Protocol.SourceGenerator.Json;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;

namespace Kafka.Protocol.SourceGenerator;

[Generator]
internal sealed class ProtocolGenerator : IIncrementalGenerator
{
    private static readonly Regex SpecificationFileRegex = new(@"^.*(\\|/)MessageDefinitions(\\|/).*.json$");
    private static readonly Regex ProtocolSpecificationRegex = new(@"^.*(\\|/)ProtocolSpecifications(\\|/)Apache Kafka.html$");
    private const string Namespace = "Kafka.Protocol";

    private const string CodeGeneratedWarningComment =
        "// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.";

    private static string MissingSpecificationFiles(
        string messageType = "") =>
        $"No {messageType}{(messageType == string.Empty ? "" : " ")}message specification files could be found. Make sure files are added as AdditionalFiles matching {SpecificationFileRegex}";

    private static readonly JsonSerializerOptions
        SpecificationFileSerializerOptions = new()
        {
            ReadCommentHandling = JsonCommentHandling.Skip,
            PropertyNameCaseInsensitive = true,
            Converters =
            {
                // The specification files defines some property types loosely, so we try to cast appropriately
                new PrimitiveToStringConverter(),
                new StringToIntegerConverter()
            }
        };

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        //Debugger.Launch();
        var protocolSpecification = context.AdditionalTextsProvider
            .ReadTextFromFilesMatching(ProtocolSpecificationRegex)
            .Select(static (text, _) =>
            {
                var apacheKafkaDefinitionPage = new HtmlDocument();
                apacheKafkaDefinitionPage.LoadHtml(text.ToString());
                return ProtocolSpecification.Load(
                    apacheKafkaDefinitionPage);
            })
            .Collect()
            .Select(
                static (array, _) =>
                {
                    if (array.IsEmpty)
                    {
                        throw new InvalidOperationException(
                            $"No protocol specification could be found. Make sure a file matching {ProtocolSpecificationRegex} is added to AdditionalFiles");
                    }

                    var specification = array.First();
                    if (!specification.ErrorCodes.Any())
                    {
                        throw new InvalidOperationException(
                            $"No error codes are defined in the protocol specification at {ProtocolSpecificationRegex}");
                    }
                    if (!specification.PrimitiveTypes.Any())
                    {
                        throw new InvalidOperationException(
                            $"No primitive types are defined in the protocol specification found at {ProtocolSpecificationRegex}");
                    }

                    return specification;
                });
        var primitiveTypes =
            protocolSpecification.Select(
                static (specification, _) =>
                    specification.PrimitiveTypes.Values);
        var errorCodes = protocolSpecification.Select(
            static (specification, _) =>
                specification.ErrorCodes.Values);
        var primitiveTypeNames = protocolSpecification
            .Select(static (specification, _) =>
                specification
                    .PrimitiveTypes.Values
                    .Select(type =>
                        type.GetClassName())
                    .ToArray());

        var messageDefinitions = context.AdditionalTextsProvider
            .ReadTextFromFilesMatching(SpecificationFileRegex)
            .Select(static (file, _) =>
            {
                var json = file.Content.ToString();
                try
                {
                    return JsonSerializer
                        .Deserialize<Message>(json,
                            SpecificationFileSerializerOptions)!
                        .AddReferencesToFields();
                }
                catch (JsonException e)
                {
                    throw new JsonException($"Caught exception deserializing: {file.Path}: {e.Message} {e.StackTrace}");
                }
            });
        var requestMessages = messageDefinitions
            .Where(message => message.IsRequest())
            .Collect()
            .ThrowIfEmpty(
                MissingSpecificationFiles("request"));
        var responseMessages = messageDefinitions
            .Where(message => message.IsResponse())
            .Collect()
            .ThrowIfEmpty(
                MissingSpecificationFiles("response"));
        var headerMessages = messageDefinitions
            .Where(message => message.IsHeader())
            .Collect()
            .ThrowIfEmpty(
                MissingSpecificationFiles("header"));
        var messages = messageDefinitions
            .Where(message => message.IsMessage())
            .Collect()
            .ThrowIfEmpty(
                MissingSpecificationFiles());
        var dataMessages = messageDefinitions
            .Where(message => message.IsData())
            .Collect()
            .ThrowIfEmpty(
                MissingSpecificationFiles("data"));

        context.RegisterSourceOutput(primitiveTypes,
            WithExceptionReporting<ICollection<PrimitiveType>>(
                GeneratePrimitiveTypes));
        context.RegisterSourceOutput(errorCodes,
            WithExceptionReporting<ICollection<ErrorCode>>(GenerateErrorCodes));

        context.RegisterSourceOutput(requestMessages,
            WithExceptionReporting<ImmutableArray<Message>>(
                GenerateCreateRequestMessageMethod));
        context.RegisterSourceOutput(requestMessages,
            WithExceptionReporting<ImmutableArray<Message>>(
                GenerateGetRequestHeaderVersionForMethod));
        context.RegisterSourceOutput(responseMessages,
            WithExceptionReporting<ImmutableArray<Message>>(
                GenerateCreateResponseMessageMethod));
        context.RegisterSourceOutput(responseMessages,
            WithExceptionReporting<ImmutableArray<Message>>(
                GenerateGetResponseHeaderVersionForMethod));
        context.RegisterSourceOutput(primitiveTypeNames.Combine(headerMessages),
            WithExceptionReporting<(string[], ImmutableArray<Message>)>(GenerateHeaderMessages));
        context.RegisterSourceOutput(primitiveTypeNames.Combine(messages),
            WithExceptionReporting<(string[], ImmutableArray<Message>)>(
                GenerateMessages));
        context.RegisterSourceOutput(primitiveTypeNames.Combine(dataMessages),
            WithExceptionReporting<(string[], ImmutableArray<Message>)>(
                GenerateData));
        context.RegisterSourceOutput(requestMessages,
            WithExceptionReporting<ImmutableArray<Message>>(
                GenerateResponseExtensions));
    }

    private static void GeneratePrimitiveTypes(
        SourceProductionContext sourceProductionContext,
        ICollection<PrimitiveType> primitiveTypes)
    {
        foreach (var primitiveType in primitiveTypes)
        {
            var className = primitiveType.GetClassName();
            var classNameWithoutGenerics = className.Split('<').First();
            var type = primitiveType.GetTypeName();
            var defaultValue = primitiveType.GetDefaultValue();
            var isNullable = primitiveType.IsNullable();
            var @params = primitiveType.IsArray() ? "params " : "";
            var genericConstraints =
                primitiveType.GetGenericArgumentConstraints();
            var nonNullableType = className.TrimStart("Nullable".ToCharArray());
            var nullableType = nonNullableType + "?";
            var description = primitiveType.Description;

            sourceProductionContext.AddSource($"Primitives/{classNameWithoutGenerics}.g.cs", ParseCSharpCode($$"""
                    #nullable enable
                    #pragma warning disable 1591
                    {{CodeGeneratedWarningComment}}
                    using System;
                    using System.Collections.Generic;
                    using System.IO;
                    using System.Threading;
                    using System.Threading.Tasks;
                    
                    namespace {{Namespace}}
                    {
                        {{Documentation.Generate(description ?? "")}}
                        public readonly partial struct {{className}} : ISerialize
                            {{Constraints.Generate(genericConstraints)}}
                        {
                            public {{type}} Value { get; }
                      
                            public {{classNameWithoutGenerics}}({{@params}}{{type}} value)
                            {
                                Value = value;
                            }
                      
                            public override bool Equals(object obj) =>
                                obj is {{className}} comparing{{classNameWithoutGenerics}} && this == comparing{{classNameWithoutGenerics}};
                      
                            public override int GetHashCode() =>
                            {{(isNullable ?
                                "Value?.GetHashCode() ?? 0;" :
                                "Value.GetHashCode();")}}
                            
                            public override string ToString() =>
                            {{(isNullable ?
                                "Value?.ToString() ?? string.Empty;" :
                                "Value.ToString();")}}
                        
                            public static bool operator == ({{className}} x, {{className}} y) =>
                                x.Value == y.Value;
                            
                            public static bool operator != ({{className}} x, {{className}} y) =>
                                !(x == y);
                            
                            public static implicit operator {{type}}({{className}} value) => 
                                value.Value;
                      
                            public static implicit operator {{className}}({{type}} value) => 
                                From(value);
                            
                            {{GenerateIfNullable($"""
                            public static implicit operator {nullableType}({className} value) =>
                                value.Value == null ? null as {nullableType} : {nonNullableType}.From(value.Value);

                            public static implicit operator {className}({nullableType} value) =>
                                From(value?.Value);
                            """)}}
                                             
                            int ISerialize.GetSize(bool asCompact) => GetSize(asCompact);
                      
                            ValueTask ISerialize.WriteToAsync(Stream writer, bool asCompact, CancellationToken cancellationToken) => 
                                WriteToAsync(writer, asCompact, cancellationToken);
                      
                            public static {{className}} From({{@params}}{{type}} value) =>
                                new {{className}}(value);
                            
                            public static {{className}} Default { get; } = From({{defaultValue}});
                        }
                    }
                  """));
            continue;

            string? GenerateIfNullable(string code) => isNullable ? code : null;
        }
    }

    private static void GenerateErrorCodes(
        SourceProductionContext sourceProductionContext,
        ICollection<ErrorCode> errorCodes)
    {
        foreach (var errorCode in errorCodes)
        {
            var exceptionName = errorCode.Error.ToPascalCase('_');
            sourceProductionContext.AddSource($"Errors/{exceptionName}.g.cs", ParseCSharpCode($$"""
                    #nullable enable
                    #pragma warning disable 1591
                    {{CodeGeneratedWarningComment}}
                    using System;
                    
                    namespace {{Namespace}}
                    {
                        {{Documentation.Generate(errorCode.Description ?? "")}}
                        public class {{exceptionName}}Exception : Exception
                        {
                            public {{exceptionName}}Exception() { }
                  
                            public {{exceptionName}}Exception(string message) : base(message) { }
                  
                            public const int ErrorCode = {{errorCode.Code}};
                            public int Code => ErrorCode;
                        }
                    }
                  """));
        }
    }

    private static void GenerateCreateRequestMessageMethod(
        SourceProductionContext sourceProductionContext,
        ImmutableArray<Message> messages)
    {
        sourceProductionContext.AddSource(
            "Messages.CreateRequestMessage.g.cs",
            GenerateCreateMessageMethod(isRequest: true, messages));
    }

    private static void GenerateCreateResponseMessageMethod(
        SourceProductionContext sourceProductionContext,
        ImmutableArray<Message> messages)
    {
        sourceProductionContext.AddSource(
            "Messages.CreateResponseMessage.g.cs",
            GenerateCreateMessageMethod(isRequest: false, messages));
    }

    private static SourceText GenerateCreateMessageMethod(
        bool isRequest,
        ImmutableArray<Message> messages) =>
        ParseCSharpCode(
            $$"""
                #nullable enable
                #pragma warning disable 1591
                {{CodeGeneratedWarningComment}}
                using System;
                using System.IO.Pipelines;
                using System.Threading;
                using System.Threading.Tasks;
                
                namespace {{Namespace}}
                {
                    public static partial class Messages 
                    {
                        public static async ValueTask<Message> Create{{(isRequest ? "Request" : "Response")}}MessageFromReaderAsync(
                            Int16 apiKey, 
                            Int16 version, 
                            PipeReader reader, 
                            CancellationToken cancellationToken = default)
                        {
                        {{messages.Aggregate("", (expression, message) => $"""
                             {expression}          
                             if ({message.Name}.ApiKey == apiKey)
                                 return await {message.Name}.FromReaderAsync(version, reader, cancellationToken).ConfigureAwait(false);
                             """)}}
                            throw new ArgumentException($"There is no {{(isRequest ? "request" : "response")}} message with api key {apiKey}");
                        }
                    }
                }
              """);

    private static void GenerateGetRequestHeaderVersionForMethod(
        SourceProductionContext sourceProductionContext,
        ImmutableArray<Message> messages)
    {
        sourceProductionContext.AddSource(
            "Messages.GetRequestHeaderVersionFor.g.cs",
            ParseCSharpCode(
                $$"""
                    #nullable enable
                    #pragma warning disable 1591
                    {{CodeGeneratedWarningComment}}
                    using System;
                    using System.IO.Pipelines;
                    using System.Threading;
                    using System.Threading.Tasks;
                    
                    namespace {{Namespace}}
                    {
                        public static partial class Messages 
                        {
                            public static Int16 GetRequestHeaderVersionFor(Int16 apiKey, Int16 version)
                            {
                                {{messages.Aggregate("", (expression, message) => $"""
                                     {expression}          
                                     if ({message.Name}.ApiKey == apiKey)
                                         return new {message.Name}(version).HeaderVersion;
                                     """)}}
                                throw new ArgumentException($"There is no request message with api key {apiKey}");
                            }
                        }
                    }
                  """));
    }

    private static void GenerateGetResponseHeaderVersionForMethod(
        SourceProductionContext sourceProductionContext,
        ImmutableArray<Message> messages)
    {
        sourceProductionContext.AddSource(
            "Messages.GetResponseHeaderVersionFor.g.cs",
            ParseCSharpCode(
                $$"""
                    #nullable enable
                    #pragma warning disable 1591
                    {{CodeGeneratedWarningComment}}
                    using System;
                    using System.IO.Pipelines;
                    using System.Threading;
                    using System.Threading.Tasks;
                    
                    namespace {{Namespace}}
                    {
                        public static partial class Messages 
                        {
                            public static Int16 GetResponseHeaderVersionFor(RequestPayload payload)
                            {
                                var apiKey = payload.Message.ApiMessageKey;
                                var version = payload.Message.Version;
                                {{messages.AggregateToString(message => $"""
                                     if ({message.Name}.ApiKey == apiKey)
                                         return new {message.Name}(version).HeaderVersion;
                                     """)}}
                                throw new ArgumentException($"There is no response message with api key {apiKey}");
                            }
                        }
                    }
                  """));
    }

    private static void GenerateHeaderMessages(
        SourceProductionContext sourceProductionContext,
        (string[] PrimitiveTypeNames, ImmutableArray<Message> Headers) input)
    {
        FieldExtensions.SetPrimitiveTypeNames(input.PrimitiveTypeNames);
        foreach (var header in input.Headers)
        {
            var versionRange = VersionRange.Parse(header.ValidVersions);
            var flexibleVersionRange = VersionRange.Parse(header.FlexibleVersions);
            var requestApiKey = new Lazy<Field>(() => header.Fields.First());
            var requestApiVersion = new Lazy<Field>(() => header.Fields.Skip(1).First());
            var requestFields = new Lazy<List<Field>>(() => header.Fields.Skip(2).ToList());

            sourceProductionContext.AddSource(
                $"Headers/{header.Name}.g.cs", ParseCSharpCode($$"""
                        #nullable enable
                        #pragma warning disable 1591
                        {{CodeGeneratedWarningComment}}
                        using System;
                        using System.IO;
                        using System.IO.Pipelines;
                        using System.Threading;
                        using System.Threading.Tasks;
                        
                        namespace {{Namespace}}
                        {
                            public class {{header.Name}}
                            {
                      	        public {{header.Name}}(Int16 version)
                      	        {
                      		        if (version.InRange(MinVersion, MaxVersion) == false) 
                      		        	throw new UnsupportedVersionException($"{{header.Name}} does not support version {version}. Valid versions are: {{header.ValidVersions}}");
                          
                      		        Version = version;
                      		        IsFlexibleVersion = {{flexibleVersionRange.GetExpression("version")}};
                      	        }
                          
                      	        public static readonly Int16 MinVersion = Int16.From({{versionRange.From ?? throw new InvalidOperationException("From cannot be null")}});
                      	        public static readonly Int16 MaxVersion = Int16.From({{versionRange.To ?? throw new InvalidOperationException("To cannot be null")}});
                          
                      	        public Int16 Version { get; }
                      	        internal bool IsFlexibleVersion { get; }
                          
                                {{Tag.GenerateCreateTagSection(header.GetTaggedFields().ToArray())}}
                      	        
                      	        internal int GetSize() => 
                      	            {{header.Fields.GenerateSizeOf()}} +
                      	            {{Tag.GenerateSizeOf()}};
                              
                      	        {{(header.IsRequestHeader() ?
                                      $$"""
                                            internal static async ValueTask<{{header.Name}}> FromReaderAsync(PipeReader reader, CancellationToken cancellationToken = default)
                                            {
                                                var instance = new {{header.Name}}(MinVersion);
                                        
                                                {{requestApiKey.Value.GenerateReadField()}}
                                                {{requestApiVersion.Value.GenerateReadField()}}
                                                                     
                                                instance = new {{header.Name}}(Messages.GetRequestHeaderVersionFor(instance.{{requestApiKey.Value.Name}}, instance.{{requestApiVersion.Value.Name}}))
                                                {
                                                    {{requestApiKey.Value.Name}} = instance.{{requestApiKey.Value.Name}},
                                                    {{requestApiVersion.Value.Name}} = instance.{{requestApiVersion.Value.Name}}
                                                };
                                            
                                                {{requestFields.Value.GenerateReadFields()}}
                                                
                                                {{Tag.GenerateReadTags(header.GetTaggedFields(), header.Name)}}                     
                                                                     
                                                return instance;
                                            }
                                        """ :
                                      $$"""
                                         internal static async ValueTask<{{header.Name}}> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default)
                                         {
                                             var instance = new {{header.Name}}(version);
                                         
                                             {{header.Fields.GenerateReadFields()}}
                                             
                                             {{Tag.GenerateReadTags(header.GetTaggedFields(), header.Name)}}
                                        
                                             return instance;
                                         }
                                        """)}}
                      		       
                      	        internal async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default)
                      	        {
                      		        {{(header.Fields.Count == 0 ?
                                              "return;" :
                                              $"""
                                               {header.Fields.GenerateWriteTos()}
                                                                                 
                                               {Tag.GenerateWriteTags()}
                                               """
                                          )}}
                      	        }
                                
                                {{header.Fields.GenerateFields(header.Name)}}
                      	        
                      	        {{header.CommonStructs.GenerateCommonStructs()}}
                      	    }
                        }
                      """));
        }
    }

    private static void GenerateMessages(SourceProductionContext sourceProductionContext,
            (string[] PrimitiveTypeNames, ImmutableArray<Message> Messages) input)
    {
        FieldExtensions.SetPrimitiveTypeNames(input.PrimitiveTypeNames);
        foreach (var message in input.Messages)
        {
            if (!message.IsMessage())
                throw new InvalidOperationException(
                    $"Expected message but got type {message.Type}");

            input.Messages.TryGetResponseMessageDefinitionFrom(message, out var responseMessageDefinition);
            var versionRange = VersionRange.Parse(message.ValidVersions);
            var flexibleVersionRange = VersionRange.Parse(message.FlexibleVersions);

            sourceProductionContext.AddSource(
                $"Messages/{message.Name}.g.cs", ParseCSharpCode($$"""
                        #nullable enable
                        #pragma warning disable 1591
                        {{CodeGeneratedWarningComment}}
                        using System;
                        using System.Collections.Generic;
                        using System.IO;
                        using System.IO.Pipelines;
                        using System.Linq;
                        using System.Threading;
                        using System.Threading.Tasks;
                        using Kafka.Protocol.Records;
                                              
                        // ReSharper disable MemberHidesStaticFromOuterClass FromReaderAsync will cause a lot of these warnings
                        namespace {{Namespace}}
                        {
                            public class {{message.Name}} : Message{{(responseMessageDefinition is not null ? $", IRespond<{responseMessageDefinition.Name}>" : "")}} 
                            {
                      	        public {{message.Name}}(Int16 version) 
                      	        {
                      		        if (version.InRange(MinVersion, MaxVersion) == false) 
                      		    	    throw new UnsupportedVersionException($"{{message.Name}} does not support version {version}. Valid versions are: {{message.ValidVersions}}"); 
                              
                      		        Version = version;
                      		        IsFlexibleVersion = {{flexibleVersionRange.GetExpression("version")}};
                      	        }
                              
                      	        internal override Int16 ApiMessageKey => ApiKey;
                      	        public static readonly Int16 ApiKey = Int16.From({{message.ApiKey}}); 
                              
                      	        public static readonly Int16 MinVersion = Int16.From({{versionRange.From ?? throw new InvalidOperationException("From cannot be null")}});
                      	        public static readonly Int16 MaxVersion = Int16.From({{versionRange.To ?? throw new InvalidOperationException("To cannot be null")}}); 
                              
                      	        public override Int16 Version { get; }
                      	        internal bool IsFlexibleVersion { get; } 
                              
                      	        // https://github.com/apache/kafka/blob/99b9b3e84f4e98c3f07714e1de6a139a004cbc5b/generator/src/main/java/org/apache/kafka/message/ApiMessageTypeGenerator.java#L324
                      	        public Int16 HeaderVersion  
                      	        {
                      		        get 
                      		        {
                      			        {{(message.IsRequest() ?
                                              $"""
                                               {
                                                   // Version 0 of ControlledShutdownRequest has a non-standard request header
                                                   // which does not include clientId. Version 1 of ControlledShutdownRequest
                                                   // and later use the standard request header.								
                                                   (message.ApiKey == 7).IfTrue(
                                                       """
                                                       if (Version == 0)
                                                           return 0;
                                                       """)}
                                               return (short)(IsFlexibleVersion ? 2 : 1);
                                               """ :
                                              $"{
                                                  // ApiVersionsResponse always includes a v0 header
                                                  // See KIP-511 for details
                                                  (message.ApiKey == 18 ?
                                                      "return 0;" :
                                                      "return (short)(IsFlexibleVersion ? 1 : 0);")}")}}
                      		        }
                      	        }
                              
                      	        {{Tag.GenerateCreateTagSection(message.GetTaggedFields().ToArray())}} 
                              
                      	        internal override int GetSize() =>
                      	            {{message.Fields.GenerateSizeOf()}} +
                      	            {{Tag.GenerateSizeOf()}}; 
                              
                      	        internal static async ValueTask<{{message.Name}}> FromReaderAsync(Int16 version, PipeReader reader, CancellationToken cancellationToken = default) 
                      	        {
                      		        var instance = new {{message.Name}}(version);
                      		        
                      		        {{message.Fields.GenerateReadFields()}}
                              
                      		        {{Tag.GenerateReadTags(message.GetTaggedFields(), message.Name)}}
                              
                      		        {{(message.Fields.Any() ?
                                          "return instance;" :
                                          $"return await new ValueTask<{message.Name}>(instance);")}}
                      	        }
                              
                      	        internal override async ValueTask WriteToAsync(Stream writer, CancellationToken cancellationToken = default) 
                      	        {
                      		        {{(message.Fields.Count == 0 ?
                                          "await Task.CompletedTask;" :
                                          message.Fields.GenerateWriteTos())}}
                              
                      		        {{Tag.GenerateWriteTags()}}
                      	        }
                              
                      	        {{message.Fields.GenerateFields(message.Name)}}
                              
                                {{message.CommonStructs.GenerateCommonStructs()}}
                              
                      	        {{(responseMessageDefinition is not null ?
                                      $"""
                                          public {responseMessageDefinition.Name} Respond()
                                              => new {responseMessageDefinition.Name}(Version);
                                       """ :
                                      "")}}
                            }
                        }
                      """));
        }
    }

    private static void GenerateData(SourceProductionContext sourceProductionContext,
            (string[] PrimitiveTypeNames, ImmutableArray<Message> Data) input)
    {
        FieldExtensions.SetPrimitiveTypeNames(input.PrimitiveTypeNames);
        foreach (var data in input.Data)
        {
            if (!data.IsData())
                throw new InvalidOperationException(
                    $"Expected data but got type {data.Type}");

            var versionRange = VersionRange.Parse(data.ValidVersions);
            var flexibleVersionRange = VersionRange.Parse(data.FlexibleVersions);

            sourceProductionContext.AddSource(
                $"Data/{data.Name}.g.cs", ParseCSharpCode($$"""
                        #nullable enable
                        #pragma warning disable 1591
                        {{CodeGeneratedWarningComment}}
                        using System;
                        using System.Collections.Generic;
                        using System.IO;
                        using System.IO.Pipelines;
                        using System.Linq;
                        using System.Threading;
                        using System.Threading.Tasks;
                        using Kafka.Protocol.Records;
                                              
                        // ReSharper disable MemberHidesStaticFromOuterClass FromReaderAsync will cause a lot of these warnings
                        namespace {{Namespace}}
                        {
                            public class {{data.Name}} 
                            {
                      	        public {{data.Name}}(Int16 version) 
                      	        {
                      		        if (version.InRange(MinVersion, MaxVersion) == false) 
                      		        	throw new UnsupportedVersionException($"{{data.Name}} does not support version {version}. Valid versions are: {{data.ValidVersions}}"); 
                          
                      		        Version = version;
                      		        IsFlexibleVersion = {{flexibleVersionRange.GetExpression("version")}};
                      	        } 
                          
                      	        public static readonly Int16 MinVersion = Int16.From({{versionRange.From ?? throw new InvalidOperationException("From cannot be null")}});
                      	        public static readonly Int16 MaxVersion = Int16.From({{versionRange.To ?? throw new InvalidOperationException("To cannot be null")}}); 
                              
                      	        public Int16 Version { get; }
                      	        internal bool IsFlexibleVersion { get; } 
                              
                      	        {{Tag.GenerateCreateTagSection(data.GetTaggedFields().ToArray())}} 
                              
                      	        internal int GetSize() =>
                      	            {{data.Fields.GenerateSizeOf()}} +
                      	            {{Tag.GenerateSizeOf()}}; 
                              
                      	        public static async ValueTask<{{data.Name}}> FromBytesAsync(Bytes data, CancellationToken cancellationToken = default) 
                      	        {
                      		        var pipe = new Pipe();
                      		        await pipe.Writer.WriteAsync(data.Value, cancellationToken).ConfigureAwait(false);
                      		        var reader = pipe.Reader; 
                      		        
                      		        var version = await Int16.FromReaderAsync(reader, false, cancellationToken).ConfigureAwait(false);
                      		        var instance = new {{data.Name}}(version);
                      		        
                      		        {{data.Fields.GenerateReadFields()}} 
                              
                      		        {{Tag.GenerateReadTags(data.GetTaggedFields(), data.Name)}}
                              
                      		        {{(data.Fields.Any() ?
                                          "return instance;" :
                                          $"return await new ValueTask<{data.Name}>(instance);")}}
                      	        }
                              
                      	        public async ValueTask<Bytes> ToBytesAsync(CancellationToken cancellationToken = default) 
                      	        {
                      		        var writer = new MemoryStream();
                      		        await using (writer.ConfigureAwait(false)) 
                      		        {
                      			        await Version.WriteToAsync(writer, IsFlexibleVersion, cancellationToken).ConfigureAwait(false);
                                		{{(data.Fields.Count == 0 ?
                                      "await Task.CompletedTask;" :
                                      $"{data.Fields.GenerateWriteTos()}")}}
                      			
                      			        {{Tag.GenerateWriteTags()}} 
                      			        return new Bytes(writer.ToArray());
                      		        }
                      	        }
                              
                      	        {{data.Fields.GenerateFields(data.Name)}}
                              
                      	        {{data.CommonStructs.GenerateCommonStructs()}}
                            } 
                        }
                      """));
        }
    }

    private static void GenerateResponseExtensions(SourceProductionContext sourceProductionContext, ImmutableArray<Message> requestMessages)
    {
        sourceProductionContext.AddSource(
            "ResponseExtensions.g.cs", ParseCSharpCode($$"""
                    #nullable enable
                    #pragma warning disable 1591
                    {{CodeGeneratedWarningComment}}
                                      
                    namespace {{Namespace}}
                    {
                        public static class ResponseExtensions
                        {
                            public static ApiVersionsResponse WithAllApiKeys(this ApiVersionsResponse response) =>
                                response.WithApiKeysCollection({{requestMessages.Aggregate("", (expression, requestMessage) => $"{(requestMessage.IsRequest() ? $"""
                                     {(expression == "" ? "" : expression + ",")}
                                                    key => key
                                                        .WithApiKey({requestMessage.Name}.ApiKey)
                                                        .WithMinVersion({requestMessage.Name}.MinVersion)
                                                        .WithMaxVersion({requestMessage.Name}.MaxVersion)
                                     """ : throw new InvalidOperationException($"Expected request message but got {requestMessage.Type}"))}")}});
                     }
                  }
                  """, false));
    }

    private static SourceText ParseCSharpCode(string code, bool normalize = true)
    {
        var compilationUnit = SyntaxFactory
            .ParseCompilationUnit(code, options: new CSharpParseOptions());
        if (normalize)
            compilationUnit = compilationUnit.NormalizeWhitespace();
        return compilationUnit.WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed)
            .GetText(Encoding.UTF8);
    }

    /// <summary>
    /// Exceptions thrown by source generators doesn't generate errors that gets
    /// collapsed in the error list of VS like analyzers and like analyzers multiline
    /// messages are trimmed to the first line, so we need to construct our own
    /// exception reporting that concatenates multiple lines and do some trickery
    /// with finding the stack frame for the first managed file that caused to
    /// the exception to simplify locating the issue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="handler"></param>
    /// <returns></returns>
    private static Action<SourceProductionContext, T> WithExceptionReporting<T>(
        Action<SourceProductionContext, T> handler) =>
        (productionContext, input) =>
        {
            try
            {
                handler.Invoke(productionContext, input);
            }
            catch (Exception e)
            {
                var stackTrace = new StackTrace(e, true);
                StackFrame? firstFrameWithLineNumber = null;
                for (var i = 0; i < stackTrace.FrameCount; i++)
                {
                    var frame = stackTrace.GetFrame(i);
                    if (frame.GetFileLineNumber() != 0)
                    {
                        firstFrameWithLineNumber = frame;
                        break;
                    }
                }

                var firstStackTraceLocation = firstFrameWithLineNumber == null ?
                    Location.None :
                    Location.Create(
                        firstFrameWithLineNumber.GetFileName(),
                        new TextSpan(),
                        new LinePositionSpan(
                            new LinePosition(
                                firstFrameWithLineNumber.GetFileLineNumber(),
                                firstFrameWithLineNumber.GetFileColumnNumber()),
                            new LinePosition(
                                firstFrameWithLineNumber.GetFileLineNumber(),
                                firstFrameWithLineNumber.GetFileColumnNumber() + 1)));

                productionContext.ReportDiagnostic(Diagnostic.Create(
                    UnhandledException,
                    location: firstStackTraceLocation,
                    // Only single line https://github.com/dotnet/roslyn/issues/1455
                    messageArgs: [e.ToString().Replace("\r\n", " |").Replace("\n", " |")]));
            }
        };

    private static readonly DiagnosticDescriptor UnhandledException =
        new(
            id: "KP0001",
            title: "Unhandled error",
            // Only single line https://github.com/dotnet/roslyn/issues/1455
            messageFormat: "{0}",
            category: "Compiler",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true,
            // Doesn't work
            description: null,
            customTags: WellKnownDiagnosticTags.AnalyzerException);
}
