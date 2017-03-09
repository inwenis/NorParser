using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Logic
{
    public class Parser
    {
        public List<Sentence> Parse(string input)
        {
            var list = new List<Sentence>();
            var sentence = new Sentence();
            sentence.Words =
                ReplaceNonAlphabetCharactersWithSpace(input)
                .Split(' ')
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .ToList();
            list.Add(sentence);
            return list;
        }

        private string ReplaceNonAlphabetCharactersWithSpace(string input)
        {
            return Regex.Replace(input, "[^a-zA-Z]+", " ");
        }
    }
}