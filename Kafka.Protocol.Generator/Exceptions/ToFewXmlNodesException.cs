using System;
using System.Xml.XPath;
using Kafka.Protocol.Generator.Extensions;

namespace Kafka.Protocol.Generator.Exceptions
{
    internal class ToFewXmlNodesException : Exception
    {
        public ToFewXmlNodesException(string name, IXPathNavigable currentNode, int expectedCount, int currentCount)
            : base(BuildMessage(name, currentNode, expectedCount, currentCount))
        {
        }

        private static string BuildMessage(string name, IXPathNavigable currentNode, int expectedCount, int currentCount)
        {
            return $"To few nodes {currentNode.CreateNavigator().GetPath()}/{name}. Expected {expectedCount}, got {currentCount}.";
        }
    }
}