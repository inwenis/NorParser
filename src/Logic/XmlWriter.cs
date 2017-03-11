using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Logic
{
    public class XmlWriter
    {
        public XDocument Write(List<Sentence> input)
        {
            var sentenceElements = input.Select(sentence =>
            {
                var wordElements = sentence.Words.Select(word => new XElement("word", word));
                return new XElement("sentence", wordElements);
            });
            var rootElement = new XElement("text", sentenceElements);
            var xmlDeclaration = new XDeclaration("1.0", "UTF-8", "yes");
            return new XDocument(xmlDeclaration, rootElement);
        }
    }
}
