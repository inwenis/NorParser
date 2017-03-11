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
            var sentences = input.Split('.');
            foreach (var sentence in sentences)
            {
                var words = ReplaceNonAlphabetCharactersWithSpace(sentence)
                    .Split(' ')
                    .Where(w => !string.IsNullOrWhiteSpace(w))
                    .OrderBy(s => s)
                    .ToList();
                list.Add(new Sentence {Words = words});
            }
            return list;
        }

        private string ReplaceNonAlphabetCharactersWithSpace(string input)
        {
            return Regex.Replace(input, "[^a-zA-Z]+", " ");
        }
    }
}