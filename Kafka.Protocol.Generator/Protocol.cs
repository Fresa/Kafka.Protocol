using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HtmlAgilityPack;
using Kafka.Protocol.Generator.Extensions;

namespace Kafka.Protocol.Generator
{
    internal class Protocol
    {
        private Protocol(HtmlDocument definition)
        {
            ErrorCodes = ParseErrorCodes(definition.DocumentNode);
        }

        internal static Protocol Load(HtmlDocument definition)
        {
            return new Protocol(definition);
        }

        public IDictionary<int, ErrorCode> ErrorCodes { get; private set; }

        private readonly string[] _errorPropertyNames =
        {
            "Error",
            "Code",
            "Retriable",
            "Description"
        };

        private const string ProtocolErrorCodesXPath = "//*[contains(@id,'protocol_error_codes')]/..";

        private IDictionary<int, ErrorCode> ParseErrorCodes(HtmlNode node)
        {
            var rows = node
                .SelectFirst(ProtocolErrorCodesXPath)
                .GetFirstSiblingNamed("table")
                .SelectAtLeast(1, "tbody/tr");

            var headerValues = rows
                .First()
                .SelectExactly(_errorPropertyNames.Length, "th");

            for (var i = 0; i < _errorPropertyNames.Length; i++)
            {
                var errorPropertyName = headerValues[i].InnerText;
                if (errorPropertyName != _errorPropertyNames[i])
                {
                    throw new ArgumentException($"Expected header property at position {i} to be '{_errorPropertyNames[i]}' but found {errorPropertyName}");
                }
            }

            return rows
                .Skip(1)
                .Select(row => row
                    .SelectExactly(_errorPropertyNames.Length, "td"))
                .Select(ParseErrorCode)
                .ToDictionary(
                    errorCode => errorCode.Code, 
                    errorCode => errorCode);
        }

        private ErrorCode ParseErrorCode(HtmlNodeCollection errorPropertyValues)
        {
            var errorCode = new ErrorCode();
            for (var i = 0; i < errorPropertyValues.Count; i++)
            {
                var errorPropertyValue = errorPropertyValues[i];
                var errorPropertyName = _errorPropertyNames[i];

                var errorCodeProperty = errorCode
                    .GetType()
                    .GetProperty(errorPropertyName,
                        BindingFlags.Public | BindingFlags.Instance);

                if (errorCodeProperty == null)
                {
                    throw new InvalidOperationException(
                        $"Missing property '{errorPropertyName}' on type {errorCode.GetType()}");
                }

                var value = Convert.ChangeType(errorPropertyValue.InnerText, errorCodeProperty.PropertyType);
                errorCodeProperty.SetValue(errorCode, value);
            }

            return errorCode;
        }

    }
}