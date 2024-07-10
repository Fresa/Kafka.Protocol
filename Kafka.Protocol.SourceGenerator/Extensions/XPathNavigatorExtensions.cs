using System.Xml;
using System.Xml.XPath;

namespace Kafka.Protocol.SourceGenerator.Extensions
{
    internal static class XPathNavigatorExtensions
    {
        public static string GetPath(this XPathNavigator navigator)
        {
            var path = new List<string>();
            for (var node = navigator.UnderlyingObject as XmlNode; node != null; node = node.ParentNode)
            {
                var append = node.LocalName;
                if (node.Attributes?.Count > 0)
                {
                    var attributeExpression = new List<string>();
                    foreach (XmlAttribute nodeAttribute in node.Attributes)
                    {
                        attributeExpression.Add($"@{nodeAttribute.LocalName}='{nodeAttribute.Value}'");
                    }
                    append += $"[{string.Join(" and ", attributeExpression)}]";
                }
                else if (node.ParentNode != null && node.ParentNode.ChildNodes.Count > 1)
                {
                    append += "[";

                    var index = 0;
                    var sibling = node;
                    while (sibling.PreviousSibling != null)
                    {
                        if (node.LocalName == sibling.PreviousSibling.LocalName)
                        {
                            index++;
                        }
                        sibling = sibling.PreviousSibling;
                    }

                    append += index;
                    append += "]";
                }

                path.Insert(0, append);
            }

            return string.Join("/", path);
        }
    }
}