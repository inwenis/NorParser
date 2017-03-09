using System.Collections.Generic;
using System.Linq;
using Logic;
using Machine.Specifications;

[Subject("Parser")]
class When_parsing_a_simple_sentence
{
    Establish context = () =>
    {
        input = "Mary had a little lamb";
        sut = new Parser();
    };

    Because of = () => {
        output = sut.Parse(input);
    };

    It returns_one_sentence = () => {
        output.Count.ShouldEqual(1);
    };

    It returns_all_words = () => {
        output.First().Words.ShouldContainOnly("Mary", "had", "a", "little", "lamb");
    };

    static Parser sut;
    static string input;
    static List<Sentence> output;
}