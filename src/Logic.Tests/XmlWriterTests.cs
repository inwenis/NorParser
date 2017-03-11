using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Logic;
using Machine.Specifications;

[Subject(typeof(XmlWriter))]
class Serializing_simple_sentence
{
    Establish context = () =>
    {
        input = new List<Sentence>
        {
            new Sentence {Words = new List<string> {"a", "bb", "ccc"}}
        };
        sut = new XmlWriter();
    };

    Because of = () =>
    {
        result = sut.Write(input);
    };

    It returns_all_words_from_input = () =>
    {
        result
            .XPathSelectElements("/text/sentence/word")
            .Select(n => n.Value)
            .ShouldContain("a", "bb", "ccc");
    };

    static XmlWriter sut;
    static List<Sentence> input;
    static XDocument result;
}
