using Logic;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ConvertToXml(string text)
        {
            var parser = new Parser();
            var sentences = parser.Parse(text);
            var xmlWriter = new XmlWriter();
            var xDocument = xmlWriter.Write(sentences);
            ViewData["ConversionResult"] = xDocument.ToString();
            return View("Index");
        }

        public IActionResult ConvertToCsv(string text)
        {
            var parser = new Parser();
            var sentences = parser.Parse(text);
            var csvWriter = new CsvWriter();
            var csv = csvWriter.Write(sentences);
            ViewData["ConversionResult"] = csv;
            return View("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
