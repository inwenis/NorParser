using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using NorParser;

[Subject(typeof(Parser))]
class Parsing_a_simple_sentence
{
    Establish context = () =>
    {
        sut = new Parser();
    };

    Because of = () =>
    {
        output = sut.Parse("Mary had a little lamb.");
    };

    It returns_one_sentence = () =>
    {
        output.Count.ShouldEqual(1);
    };

    It returns_all_words = () =>
    {
        output.First().Words.ShouldContainOnly("Mary", "had", "a", "little", "lamb");
    };

    It returns_words_in_alphabetical_order = () =>
    {
        output.First().Words.ShouldEqual(new List<string> {"a", "had", "lamb", "little", "Mary"});
    };

    It does_not_return_empty_sentences = () =>
    {
        output.ShouldNotContain(s => s.Words== null || s.Words.Count == 0);
    };

    static Parser sut;
    static List<Sentence> output;
}

[Subject(typeof(Parser))]
class Parsing_sentence_with_multiple_spaces
{
    Establish context = () =>
    {
        sut = new Parser();
    };

    Because of = () =>
    {
        output = sut.Parse("  had \t ");
    };

    It returns_only_valid_nonempty_words = () => {
        output.First().Words.ShouldContainOnly("had");
    };

    static Parser sut;
    static List<Sentence> output;
}

[Subject(typeof(Parser))]
class Parsing_sentence_with_nonalphabetic_characters
{
    Establish context = () =>
    {
        sut = new Parser();
    };

    Because of = () =>
    {
        output = sut.Parse("  i ~ had}a @mad# $ % ^ & * ( ) _ + - = ` { } |  : \" < > [ ] \\ ; , . / * + , ");
    };

    It treats_non_alphabetic_characters_as_spaces = () =>
    {
        output.First().Words.ShouldContainOnly("i", "had", "a", "mad");
    };

    static Parser sut;
    static List<Sentence> output;
}

[Subject(typeof(Parser))]
class Parsing_multiple_sentences_separated_by_dots
{
    Establish context = () =>
    {
        sut = new Parser();
    };

    Because of = () =>
    {
        output = sut.Parse("i had a mad idea. The idea was great. Why didn't we use it");
    };

    It returnes_all_sentences = () =>
    {
        output.Count.ShouldEqual(3);
    };

    static Parser sut;
    static List<Sentence> output;
}

[Subject(typeof(Parser))]
class Parsing_words_with_special_nonalphabetic_characters
{
    Establish context = () =>
    {
        sut = new Parser();
    };

    Because of = () =>
    {
        output = sut.Parse("don't Graham-Cumming lists'");
    };

    It treats_special_nonalphabetic_characters_as_part_of_words = () =>
    {
        output.First().Words.ShouldContain("don't", "Graham-Cumming", "lists'");
    };

    static Parser sut;
    static List<Sentence> output;
}

[Subject(typeof(Parser))]
class Parsing_sentences_with_special_characters_not_being_part_of_words
{
    Establish context = () =>
    {
        sut = new Parser();
    };

    Because of = () =>
    {
        output = sut.Parse("aaa ' bbb - ccc '&' *-= -xxx 'yyy zzz-");
    };

    It return_only_valid_words = () =>
    {
        output.First().Words.ShouldContainOnly("aaa", "bbb", "ccc", "xxx", "yyy", "zzz");
    };

    static Parser sut;
    static List<Sentence> output;
}

[Subject(typeof(Parser))]
class Parsing_sentence_with_only_nonalphabetical_characters
{
    Establish context = () =>
    {
        sut = new Parser();
    };

    Because of = () =>
    {
        output = sut.Parse("this is a sentence. ';[] ;'[] - 0 909 . the previous sentence was not a real sentece");
    };

    It does_not_return_empty_sentence = () =>
    {
        output.ShouldEachConformTo(s => s.Words.Any());
    };

    static Parser sut;
    static List<Sentence> output;
}

[Subject(typeof(Parser))]
class Parsing_sentence_with_different_sentence_separators
{
    Establish context = () =>
    {
        sut = new Parser();
    };

    Because of = () =>
    {
        output = sut.Parse("aaa. bbb ? ccc ! xxx");
    };

    It separates_sentences_for_every_separator = () =>
    {
        output.Count.ShouldEqual(4);
    };

    static Parser sut;
    static List<Sentence> output;
}