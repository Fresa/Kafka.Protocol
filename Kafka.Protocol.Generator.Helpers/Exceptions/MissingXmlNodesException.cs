using System;
using System.Xml.XPath;
using Kafka.Protocol.Generator.Helpers.Extensions;

namespace Kafka.Protocol.Generator.Helpers.Exceptions
{
    internal class MissingXmlNodesException : Exception
    {
        public MissingXmlNodesException(string name, IXPathNavigable currentNode)
            : base(BuildMessage(name, currentNode))
        {
        }

        private static string BuildMessage(string name, IXPathNavigable currentNode)
        {
            return $"Missing nodes: {currentNode.CreateNavigator().GetPath()}/{name}";
        }
    }
}