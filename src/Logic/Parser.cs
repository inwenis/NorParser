using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class Parser
    {
        public List<Sentence> Parse(string input)
        {
            var list = new List<Sentence>();
            var sentence = new Sentence();
            sentence.Words = input
                .Split(' ')
                .Where(w => !string.IsNullOrWhiteSpace(w))
                .ToList();
            list.Add(sentence);
            return list;
        }
    }
}