using System;
using System.Xml.XPath;
using Kafka.Protocol.Generator.Helpers.Extensions;

namespace Kafka.Protocol.Generator.Helpers.Exceptions
{
    internal class MissingXmlNodeSiblingException : Exception
    {
        public MissingXmlNodeSiblingException(string name, IXPathNavigable currentNode)
            : base(BuildMessage(name, currentNode))
        {
        }

        private static string BuildMessage(string name, IXPathNavigable currentNode)
        {
            return $"Missing node: {name} after {currentNode.CreateNavigator().GetPath()}";
        }
    }
}