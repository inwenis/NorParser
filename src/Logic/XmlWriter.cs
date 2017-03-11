using System.Collections.Generic;
using System.Xml.Linq;

namespace Logic
{
    public class XmlWriter
    {
        public XDocument Write(List<Sentence> input)
        {
            var root = new XElement("text");
            foreach (var sentence in input)
            {
                var sentenceElement = new XElement("sentence");
                foreach (var word in sentence.Words)
                {
                    sentenceElement.Add(new XElement("word", word));
                }
                root.Add(sentenceElement);
            }
            var xmlDeclaration = new XDeclaration("1.0", "UTF-8", "yes");
            return new XDocument(xmlDeclaration, root);
        }
    }
}
