using System.Collections.Generic;

namespace NorParser
{
    public class Sentence
    {
        public List<string> Words { get; set; }

        public Sentence(List<string> words)
        {
            Words = words;
        }
    }
}