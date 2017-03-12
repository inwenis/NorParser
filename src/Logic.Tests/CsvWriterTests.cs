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

    It returnes_csv_with_proper_column_headers = () =>
    {
        result.ShouldStartWith(", Word 1, Word 2, Word 3");
    };

    It returnes_csv_with_row_header_for_each_sentence = () =>
    {
        result.Split('\n')[1].ShouldStartWith("Sentence 1, ");
    };

    static CsvWriter sut;
    static List<Sentence> input;
    static string result;
}
