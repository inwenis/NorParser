using System.IO;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Http;
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

        public IActionResult TextFileToXml(IFormFile textFile)
        {
            var reader = new StreamReader(textFile.OpenReadStream());
            var text = reader.ReadToEnd();
            return ConvertToXml(text);
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

        public IActionResult TextFileToCsv(IFormFile textFile)
        {
            var reader = new StreamReader(textFile.OpenReadStream());
            var text = reader.ReadToEnd();
            return ConvertToCsv(text);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
