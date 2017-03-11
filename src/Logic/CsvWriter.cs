using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class CsvWriter
    {
        public string Write(List<Sentence> sentences)
        {
            var sb = new StringBuilder();
            foreach (var sentence in sentences)
            {
                sb.AppendLine(string.Join(", ", sentence.Words));
            }
            return sb.ToString();
        }
    }
}
