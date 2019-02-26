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
        internal static Protocol Load(HtmlDocument definition)
        {
            return new Protocol(definition);
        }

        private Protocol(HtmlDocument definition)
        {
            ErrorCodes = ParseErrorCodes(definition.DocumentNode);
            Requests = ParseRequests(definition.DocumentNode);
        }

        internal IDictionary<int, ErrorCode> ErrorCodes { get; }

        internal IDictionary<int, Request> Requests { get; }

        private readonly string[] _apiKeyPropertyNames =
        {
            "Name",
            "Key"
        };

        private const string ProtocolApiKeysXPath = "//*[contains(@id,'protocol_api_keys')]/..";

        private IDictionary<int, Request> ParseRequests(HtmlNode node)
        {
            var rows = node
                .SelectFirst(ProtocolApiKeysXPath)
                .GetFirstSiblingNamed("table")
                .SelectAtLeast(1, "tbody/tr");

            var headerValues = rows
                .First()
                .SelectExactly(_apiKeyPropertyNames.Length, "th");

            for (var i = 0; i < _apiKeyPropertyNames.Length; i++)
            {
                var apiKeyPropertyName = headerValues[i].InnerText;
                if (apiKeyPropertyName != _apiKeyPropertyNames[i])
                {
                    throw new ArgumentException($"Expected property name at position {i} to be '{_apiKeyPropertyNames[i]}' but found {apiKeyPropertyName}");
                }
            }

            return rows
                .Skip(1)
                .Select(row => row
                    .SelectExactly(_apiKeyPropertyNames.Length, "td"))
                .Select(ParseRequest)
                .ToDictionary(
                    errorCode => errorCode.Key,
                    errorCode => errorCode);
        }

        private Request ParseRequest(HtmlNodeCollection errorPropertyValues)
        {
            var request = new Request();
            for (var i = 0; i < errorPropertyValues.Count; i++)
            {
                var apiKeyPropertyValue = errorPropertyValues[i].FirstChild;
                var apiKeyPropertyName = _apiKeyPropertyNames[i];

                var errorCodeProperty = request
                    .GetType()
                    .GetProperty(apiKeyPropertyName,
                        BindingFlags.Public | BindingFlags.Instance);

                if (errorCodeProperty == null)
                {
                    throw new InvalidOperationException(
                        $"Missing property '{apiKeyPropertyName}' on type {request.GetType()}");
                }

                var value = Convert.ChangeType(apiKeyPropertyValue.InnerText, errorCodeProperty.PropertyType);
                errorCodeProperty.SetValue(request, value);
            }

            return request;
        }

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
                    throw new ArgumentException($"Expected property name at position {i} to be '{_errorPropertyNames[i]}' but found {errorPropertyName}");
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

    internal class Request
    {
        public string Name { get; internal set; }
        public int Key { get; internal set; }
    }
}