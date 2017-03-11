using Logic;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AppController : Controller
    {
        public IActionResult ConvertToXml(string text)
        {
            var parser = new Parser();
            var sentences = parser.Parse(text);
            var xmlWriter = new XmlWriter();
            var xDocument = xmlWriter.Write(sentences);
            ViewData["Xml"] = xDocument.ToString();
            return View();
        }

        public IActionResult ConvertToCsv(string text)
        {
            var parser = new Parser();
            var sentences = parser.Parse(text);
            var csvWriter = new CsvWriter();
            var csv = csvWriter.Write(sentences);
            ViewData["Csv"] = csv;
            return View();
        }
    }
}