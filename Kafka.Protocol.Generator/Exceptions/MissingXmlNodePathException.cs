using System;
using System.Xml.XPath;
using Kafka.Protocol.Generator.Extensions;

namespace Kafka.Protocol.Generator.Exceptions
{
    internal class MissingXmlNodePathException : Exception
    {
        public MissingXmlNodePathException(string name, IXPathNavigable currentNode)
            : base(BuildMessage(name, currentNode))
        {
        }

        private static string BuildMessage(string name, IXPathNavigable currentNode)
        {
            return $"Missing node: {currentNode.CreateNavigator().GetPath()}/{name}";
        }
    }
}