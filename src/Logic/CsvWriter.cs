using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class CsvWriter
    {
        public string Write(List<Sentence> sentences)
        {
            var stringBuilder = new StringBuilder();

            var maxWordsCount = sentences.Max(s => s.Words.Count);
            var columnHeaders = Enumerable.Range(1, maxWordsCount).Select(i => $", Word {i}");
            stringBuilder.AppendLine(string.Join("", columnHeaders));

            var index = 1;
            foreach (var sentence in sentences)
            {
                stringBuilder.Append($"Sentence {index}, ");
                stringBuilder.AppendLine(string.Join(", ", sentence.Words));
                index++;
            }

            return stringBuilder.ToString();
        }
    }
}
