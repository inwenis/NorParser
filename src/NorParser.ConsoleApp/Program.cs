using System;
using Logic;

namespace NorParser.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var parser = new Parser();
            var inputSimple = "Mary had a little lamb. Peter called for the wolf, and Aesop came. Cinderella likes shoes.";
            var inputWithNewLinesAndExcessiveSpaces =
                "  Mary   had a little  lamb  . \n" +
                "\n" +
                "\n" +
                "Peter called for the wolf, and Aesop came." +
                "Cinderella  likes shoes.";

            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine(inputSimple);
            foreach (var sentence in parser.Parse(inputSimple))
            {
                Console.WriteLine("sentence:");
                foreach (var word in sentence.Words)
                {
                    Console.WriteLine($"\t{word}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine(inputWithNewLinesAndExcessiveSpaces);
            foreach (var sentence in parser.Parse(inputWithNewLinesAndExcessiveSpaces))
            {
                Console.WriteLine("sentence:");
                foreach (var word in sentence.Words)
                {
                    Console.WriteLine($"\t{word}");
                }
            }

            var sentences = parser.Parse(inputSimple);
            var xmlWriter = new XmlWriter();
            var xDocument = xmlWriter.Write(sentences);
            Console.WriteLine("------------------------------");
            Console.WriteLine(xDocument.ToString());

            var csvWriter = new CsvWriter();
            var csv = csvWriter.Write(sentences);
            Console.WriteLine("------------------------------");
            Console.WriteLine(csv);

            Console.ReadLine();
        }
    }
}
