using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Kafka.Protocol.Generator.Helpers;
using Kafka.Protocol.Generator.Helpers.Definitions;
using Kafka.Protocol.Generator.Helpers.Definitions.Messages;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Kafka.Protocol.SourceGenerator
{
    [Generator]
    public partial class ProtocolGenerator : IIncrementalGenerator
    {
        private static readonly Regex SpecificationFileRegex = new(@"^.*(\\|/)MessageDefinitions(\\|/).*.json$");
        private static readonly Regex ProtocolSpecificationRegex = new(@"^.*(\\|/)ProtocolSpecifications(\\|/)Apache Kafka.html$");

        private static readonly JsonSerializerOptions
            _specificationFileSerializerOptions = new()
            {
                ReadCommentHandling = JsonCommentHandling.Skip
            };

    public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            //Debugger.Launch();
            var protocolSpecifications = context.AdditionalTextsProvider
                .Where(static file =>
                     ProtocolSpecificationRegex.IsMatch(file.Path))
                .Select(static (text, token) =>
                    text.GetText(token))
                .Where(static text => text is not null)
                .Select(static (text, _) => text!)
                .Select(static (text, _) =>
                {
                    var apacheKafkaDefinitionPage = new HtmlDocument();
                    apacheKafkaDefinitionPage.LoadHtml(text.ToString());
                    return ProtocolSpecification.Load(
                        apacheKafkaDefinitionPage);
                })
                .Collect();
            var protocolSpecification = protocolSpecifications.Select(
                static (array, _) =>
                {
                    if (array.IsEmpty)
                    {
                        throw new InvalidOperationException(
                            $"No protocol specification could be found. Make sure a file matching {ProtocolSpecificationRegex} is added to AdditionalFiles");
                    }
                    return array.First();
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

            var specifications = context.AdditionalTextsProvider
                .Where(static file => SpecificationFileRegex.IsMatch(file.Path));
            var specificationContent = specifications
                .Select(static (text, token) =>
                    text.GetText(token))
                .Where(static text => text is not null)
                .Select(static (text, _) => text!);
            var messageDefinitions = specificationContent
                .Select(static (text, _) =>
                    JsonSerializer
                        .Deserialize<Message>(text.ToString(), _specificationFileSerializerOptions)!
                        .AddReferencesToFields())
                .Collect()
                .Select((array, _) =>
                {
                    if (array.IsEmpty)
                    {
                        throw new InvalidOperationException(
                            $"No message specification files could be found. Make sure files are added as AdditionalFiles matching {SpecificationFileRegex}");
                    }
                    return array;
                });
            
            //context.RegisterSourceOutput(primitiveTypes, GeneratePrimitiveTypes);
            //context.RegisterSourceOutput(errorCodes, GenerateErrorCodes);
            
            context.RegisterSourceOutput(primitiveTypeNames.Combine(messageDefinitions), GenerateMessages);
        }
        
        private void GenerateErrorCodes(SourceProductionContext arg1, ICollection<ErrorCode> arg2)
        {
            arg1.AddSource("test.cs", @"
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

        private void GeneratePrimitiveTypes(SourceProductionContext arg1, ICollection<PrimitiveType> arg2)
        {
            foreach (var primitiveType in arg2)
            {
                arg1.AddSource($"{primitiveType.Type}.g.cs", $@"
namespace Generated
{{
    public class {primitiveType.Type}
    {{
        public static void PrintTexts()
        {{
            System.Console.WriteLine(""Hello world"");
        }}
    }}
}}");
            }
            
        }

        private void GenerateMessages(SourceProductionContext arg1, (string[] Left, ImmutableArray<Message> Right) arg2)
        {
            arg1.AddSource("test3.cs", @"
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

        
    }
}
