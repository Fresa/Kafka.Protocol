using System.Linq;
using HtmlAgilityPack;
using Kafka.Protocol.Generator.Exceptions;

namespace Kafka.Protocol.Generator.Extensions
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
    }
}