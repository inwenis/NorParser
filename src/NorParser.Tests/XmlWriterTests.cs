using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Machine.Specifications;
using NorParser;

[Subject(typeof(XmlWriter))]
class Serializing_simple_sentence
{
    Establish context = () =>
    {
        input = new List<Sentence>
        {
            new Sentence(new List<string> {"a", "bb", "ccc"})
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

    It returnes_xml_with_proper_declaration = () =>
    {
        result.Declaration.Encoding.ShouldEqual("UTF-8");
        result.Declaration.Version.ShouldEqual("1.0");
        result.Declaration.Standalone.ShouldEqual("yes");
    };

    static XmlWriter sut;
    static List<Sentence> input;
    static XDocument result;
}

[Subject(typeof(XmlWriter))]
class Serializing_multiple_sentences
{
    Establish context = () =>
    {
        input = new List<Sentence>
        {
            new Sentence(new List<string> {"a", "bb", "ccc"}),
            new Sentence(new List<string> {"d", "ee", "fff"})
        };
        sut = new XmlWriter();
    };

    Because of = () =>
    {
        result = sut.Write(input);
    };

    It returnes_xml_with_element_for_each_sentence = () =>
    {
        result.XPathSelectElements("/text/sentence").Count().ShouldEqual(2);
    };

    static XmlWriter sut;
    static List<Sentence> input;
    static XDocument result;
}
