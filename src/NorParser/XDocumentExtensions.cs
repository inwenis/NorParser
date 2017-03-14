using System.Xml.Linq;

namespace NorParser
{
    public static class XDocumentExtensions
    {
        public static string ToStringWithDeclaration(this XDocument xDoc)
        {
            return $"{xDoc.Declaration}\n{xDoc}";
        }
    }
}