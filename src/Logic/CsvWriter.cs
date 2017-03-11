using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class CsvWriter
    {
        public string Write(List<Sentence> sentences)
        {
            var maxWordsCount = sentences.Max(s => s.Words.Count);
            var columnHeaders = Enumerable.Range(1, maxWordsCount).Select(i => $", Word {i}");
            var sb = new StringBuilder();
            sb.AppendLine(string.Join("", columnHeaders));
            foreach (var sentence in sentences)
            {
                sb.AppendLine(string.Join(", ", sentence.Words));
            }
            return sb.ToString();
        }
    }
}
