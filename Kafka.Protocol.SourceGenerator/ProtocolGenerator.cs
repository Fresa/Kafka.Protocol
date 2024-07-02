using System.Collections.Immutable;
using System.Text.Json;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Kafka.Protocol.Generator.Helpers;
using Kafka.Protocol.Generator.Helpers.Definitions;
using Kafka.Protocol.Generator.Helpers.Definitions.Messages;
using Kafka.Protocol.Generator.Helpers.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Kafka.Protocol.SourceGenerator;

[Generator]
public partial class ProtocolGenerator : IIncrementalGenerator
{
    private static readonly Regex SpecificationFileRegex = new(@"^.*(\\|/)MessageDefinitions(\\|/).*.json$");
    private static readonly Regex ProtocolSpecificationRegex = new(@"^.*(\\|/)ProtocolSpecifications(\\|/)Apache Kafka.html$");
    private const string Namespace = "Kafka.Protocol";

    private const string CodeGeneratedWarningComment =
        "// WARNING! THIS FILE IS AUTO-GENERATED! DO NOT EDIT.";

    private static string GenerateMissingSpecificationFiles(
        string messageType = "") =>
        $"No {messageType}{(messageType == string.Empty ? "" : " ")}message specification files could be found. Make sure files are added as AdditionalFiles matching {SpecificationFileRegex}";

    private static readonly JsonSerializerOptions
        SpecificationFileSerializerOptions = new()
        {
            ReadCommentHandling = JsonCommentHandling.Skip
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
            .Select(static (text, _) =>
                JsonSerializer
                    .Deserialize<Message>(text.ToString(), SpecificationFileSerializerOptions)!
                    .AddReferencesToFields())
            .Collect()
            .Select(static (array, _) =>
            {
                if (array.IsEmpty)
                {
                    throw new InvalidOperationException(
                        $"No message specification files could be found. Make sure files are added as AdditionalFiles matching {SpecificationFileRegex}");
                }
                return array;
            });
        var requestMessages = messageDefinitions
            .Where(message => message.IsRequest())
            .Collect()
            .ThrowIfEmpty(
                GenerateMissingSpecificationFiles("request"));
        var responseMessages = messageDefinitions
            .Where(message => message.IsResponse())
            .Collect()
            .ThrowIfEmpty(
                GenerateMissingSpecificationFiles("response"));
        var headerMessages = messageDefinitions
            .Where(message => message.IsHeader())
            .Collect()
            .ThrowIfEmpty(
                GenerateMissingSpecificationFiles("header"));
        var messages = messageDefinitions
            .Where(message => message.IsMessage())
            .Collect()
            .ThrowIfEmpty(
                GenerateMissingSpecificationFiles());
        var dataMessages = messageDefinitions
            .Where(message => message.IsData())
            .Collect()
            .ThrowIfEmpty(
                GenerateMissingSpecificationFiles("data"));

        context.RegisterSourceOutput(primitiveTypes, GeneratePrimitiveTypes);
        context.RegisterSourceOutput(errorCodes, GenerateErrorCodes);
        context.RegisterSourceOutput(primitiveTypeNames.Combine(messageDefinitions), GenerateMessages);
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

            sourceProductionContext.AddSource($"{classNameWithoutGenerics}.g.cs", ParseCSharpCode($$"""
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


    private void GenerateMessages(SourceProductionContext arg1, (string[] Left, ImmutableArray<Message> Right) arg2)
    {
        arg1.AddSource("test5.cs", @"
namespace Generated
{
    public class AdditionalTextList
    {
        public static void PrintTexts()
        {
            System.Console.WriteLine(""Hello world"");
        }
    }
}");
    }

    private static string ParseCSharpCode(string code) =>
        SyntaxFactory.ParseCompilationUnit(code, options: new CSharpParseOptions())
            .NormalizeWhitespace()
            .WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed)
            .GetText()
            .ToString();
}
