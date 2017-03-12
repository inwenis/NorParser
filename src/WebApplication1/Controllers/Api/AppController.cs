using Logic;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers.Api
{
    public class AppController : Controller
    {
        [HttpPost("api/toXml")]
        public IActionResult ToXml([FromBody]string text)
        {
            var parser = new Parser();
            var sentences = parser.Parse(text);
            var xmlWriter = new XmlWriter();
            var xDocument = xmlWriter.Write(sentences);
            return Content(xDocument.ToString());
        }

        [HttpPost("api/toCsv")]
        public IActionResult ToCsv(string text)
        {
            var parser = new Parser();
            var sentences = parser.Parse(text);
            var csvWriter = new CsvWriter();
            var csv = csvWriter.Write(sentences);
            return Content(csv);
        }
    }
}
