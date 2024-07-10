using System.Xml.XPath;
using Kafka.Protocol.SourceGenerator.Extensions;

namespace Kafka.Protocol.SourceGenerator.Exceptions
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