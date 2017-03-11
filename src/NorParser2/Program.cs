using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;

namespace NorParser2
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

            Console.ReadKey();
        }
    }
}
