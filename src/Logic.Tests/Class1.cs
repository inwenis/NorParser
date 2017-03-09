using System.Collections.Generic;
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

    static Parser sut;
    static string input;
    static List<object> output;
}