using System.Collections.Generic;
using Logic;
using Machine.Specifications;

[Subject(typeof(CsvWriter))]
class Serializing_simple_sentence_to_csv
{
    Establish context = () =>
    {
        input = new List<Sentence>
        {
            new Sentence {Words = new List<string> {"a", "bb", "ccc"}}
        };
        sut = new CsvWriter();
    };

    Because of = () =>
    {
        result = sut.Write(input);
    };

    It returns_all_words_from_input = () =>
    {
        result.ShouldContain("a");
        result.ShouldContain("bb");
        result.ShouldContain("ccc");
    };

    static CsvWriter sut;
    static List<Sentence> input;
    static string result;
}
