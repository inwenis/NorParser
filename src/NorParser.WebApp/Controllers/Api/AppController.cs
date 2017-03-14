using Microsoft.AspNetCore.Mvc;

namespace NorParser.WebApp.Controllers.Api
{
    public class AppController : Controller
    {
        private readonly Parser _parser;

        public AppController(Parser parser)
        {
            _parser = parser;
        }

        [HttpPost("api/toXml")]
        public IActionResult ToXml([FromBody]string text)
        {
            var sentences = _parser.Parse(text);
            var xmlWriter = new XmlWriter();
            var xDocument = xmlWriter.Write(sentences);
            return Content(xDocument.ToStringWithDeclaration());
        }

        [HttpPost("api/toCsv")]
        public IActionResult ToCsv([FromBody]string text)
        {
            var sentences = _parser.Parse(text);
            var csvWriter = new CsvWriter();
            var csv = csvWriter.Write(sentences);
            return Content(csv);
        }
    }
}
