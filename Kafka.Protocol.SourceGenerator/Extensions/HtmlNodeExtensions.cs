﻿using System.Reflection;
using HtmlAgilityPack;
using Kafka.Protocol.SourceGenerator.Exceptions;

namespace Kafka.Protocol.SourceGenerator.Extensions
{
    internal static class HtmlNodeExtensions
    {
        internal static HtmlNode GetFirstSiblingNamed(this HtmlNode node, string name)
        {
            var startNode = node;
            do
            {
                node = node.NextSibling;
                if (node == null)
                {
                    throw new MissingXmlNodeSiblingException(name, startNode);
                }
            } while (node.Name != name);

            return node;
        }

        internal static HtmlNodeCollection SelectMandatoryNodes(this HtmlNode node, string xpath)
        {
            var nodes = node.SelectNodes(xpath);
            if (nodes == null)
            {
                throw new MissingXmlNodePathException(xpath, node);
            }

            return nodes;
        }

        internal static HtmlNodeCollection SelectExactly(this HtmlNode node, int expected, string xpath)
        {
            var nodes = node.SelectMandatoryNodes(xpath);

            if (nodes.Count < expected)
            {
                throw new ToFewXmlNodesException(xpath, node, expected, nodes.Count);
            }

            if (nodes.Count > expected)
            {
                throw new ToManyXmlNodesException(xpath, node, expected, nodes.Count);
            }

            return nodes;
        }

        internal static HtmlNodeCollection SelectAtLeast(this HtmlNode node, int expected, string xpath)
        {
            var nodes = node.SelectMandatoryNodes(xpath);

            if (nodes.Count < expected)
            {
                throw new ToFewXmlNodesException(xpath, node, 1, nodes.Count);
            }

            return nodes;
        }

        internal static HtmlNode SelectFirst(this HtmlNode node, string xpath)
        {
            var nodes = node.SelectAtLeast(1, xpath);

            return nodes.First();
        }

        internal delegate string ResolveCellValue(HtmlNode cellNode);

        /// <summary>
        /// Parses table cell values to property values on <see cref="T"/>
        /// by mapping table header cell values as property names
        /// </summary>
        /// <typeparam name="T">Object type to convert to</typeparam>
        /// <param name="node">Table node</param>
        /// <param name="resolveCellValue">Resolves cell value</param>
        /// <returns></returns>
        internal static IEnumerable<T> ParseTableNodeTo<T>(
            this HtmlNode node,
            ResolveCellValue? resolveCellValue = null)
            where T : class, new()
        {
            resolveCellValue = resolveCellValue ?? (htmlNode => htmlNode.InnerHtmlAsFormattedString());

            if (node.Name.Equals("table",
                    StringComparison.CurrentCultureIgnoreCase) == false)
            {
                throw new ArgumentException(
                    "Node is not a table",
                    nameof(node));
            }

            var properties = typeof(T)
                .GetProperties(
                    BindingFlags.Public | BindingFlags.Instance);

            var rows = node
                .SelectAtLeast(1, "tbody/tr");

            var headerValues = rows
                .First()
                .SelectExactly(properties.Length, "th");

            for (var i = 0; i < properties.Length; i++)
            {
                var propertyName = headerValues[i].InnerText;
                if (propertyName != properties[i].Name)
                {
                    throw new ArgumentException(
                        $"Expected property name at position {i} to be '{properties[i].Name}' but found {propertyName}");
                }
            }

            return rows
                .Skip(1)
                .Select(row => row
                    .SelectExactly(properties.Length, "td"))
                .Select(ParseTableRow);

            T ParseTableRow(
                HtmlNodeCollection tableCellValues)
            {
                var obj = new T();
                for (var i = 0; i < tableCellValues.Count; i++)
                {
                    var propertyValue = resolveCellValue(tableCellValues[i]);
                    var propertyName = properties[i].Name;

                    var property = properties
                        .FirstOrDefault(info =>
                            info.Name
                                .Equals(propertyName));

                    if (property == null)
                    {
                        throw new InvalidOperationException(
                            $"Missing property '{propertyName}' on type {obj.GetType()}");
                    }

                    var typedPropertyValue = Convert.ChangeType(propertyValue, property.PropertyType);
                    property.SetValue(obj, typedPropertyValue);
                }

                return obj;
            }
        }

        private static readonly Dictionary<string, string> HtmlTagTranslations = new Dictionary<string, string>
        {
            {"sup", "^" }
        };

        internal static string InnerHtmlAsFormattedString(this HtmlNode htmlNode)
        {
            var translated = htmlNode.InnerHtml;
            foreach (var htmlTagTranslation in HtmlTagTranslations)
            {
                translated = translated
                    .Replace($"<{htmlTagTranslation.Key}>", htmlTagTranslation.Value)
                    .Replace($"</{htmlTagTranslation.Key}>", string.Empty);
            }

            return translated;
        }
    }
}