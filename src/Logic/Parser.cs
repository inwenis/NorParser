using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Logic
{
    public class Parser
    {
        private readonly char[] _sentenceSeparators = { '.' };

        public List<Sentence> Parse(string input)
        {
            var parsedSentences = new List<Sentence>();
            var sentences = input.Split(_sentenceSeparators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var sentence in sentences)
            {
                var words = ReplaceCharactersNotAllowedInWordsWithSpaces(sentence)
                    .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Where(w => !string.IsNullOrWhiteSpace(w))
                    .Where(w => !w.All(char.IsPunctuation))
                    .OrderBy(s => s)
                    .ToList();
                parsedSentences.Add(new Sentence {Words = words});
            }
            return parsedSentences;
        }

        private string ReplaceCharactersNotAllowedInWordsWithSpaces(string input)
        {
            return Regex.Replace(input, "[^a-zA-Z'-]+", " ");
        }
    }
}