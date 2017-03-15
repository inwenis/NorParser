using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NorParser
{
    public class Parser
    {
        private readonly char[] _sentenceSeparators = { '.', '?', '!' };

        public List<Sentence> Parse(string input)
        {
            var parsedSentences = new List<Sentence>();
            var sentences = input.Split(_sentenceSeparators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var sentence in sentences)
            {
                var words = ReplaceCharactersNotAllowedInWordsWithSpaces(sentence)
                    .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(RemoveLeadingHyphen)
                    .Select(RemoveTrailingHyphen)
                    .Select(RemoveLeadingApostrophe)
                    .Where(w => !string.IsNullOrWhiteSpace(w))
                    .Where(w => !w.All(char.IsPunctuation))
                    .OrderBy(s => s)
                    .ToList();
                if(words.Any())
                {
                    parsedSentences.Add(new Sentence {Words = words});
                }
            }
            return parsedSentences;
        }

        private string RemoveLeadingApostrophe(string s)
        {
            return Regex.Replace(s, "^'+", "");
        }

        private string RemoveLeadingHyphen(string s)
        {
            return Regex.Replace(s, "^-+", "");
        }

        private string RemoveTrailingHyphen(string s)
        {
            return Regex.Replace(s, "-+$", "");
        }

        private string ReplaceCharactersNotAllowedInWordsWithSpaces(string input)
        {
            return Regex.Replace(input, "[^a-zA-Z'-]+", " ");
        }
    }
}