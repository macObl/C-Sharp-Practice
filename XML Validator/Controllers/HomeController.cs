using System;
using System.Xml;
using System.Xml.Schema;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using CST8259_Lab2.Models;

namespace CST8259_Lab2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(XMLandSchemaFileUpload xmlAndSchemaFiles)
        {

            if(xmlAndSchemaFiles == null)
                return NotFound();

            IFormFile schemaFile = xmlAndSchemaFiles.SchemaFile;
            IFormFile xmlFile = xmlAndSchemaFiles.XmlFile;

            if(schemaFile == null)
            {
                ModelState.AddModelError("SchemaFile", "A schema file is required");
            }
            if(xmlFile == null)
            {
                ModelState.AddModelError("XmlFile", "A XML file is required");
            }

            if (ModelState.IsValid)
            {
                XmlReader schemaFileReader = XmlReader.Create(schemaFile.OpenReadStream());

                XmlSchemaSet sc = new XmlSchemaSet();
                sc.Add(null, schemaFileReader);

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas = sc;

                List<XmlValidationError> validationResults = new List<XmlValidationError>();
                settings.ValidationEventHandler +=
                    (s, e) => validationResults.Add(new XmlValidationError
                    {
                        Element = ((XmlReader)s).Name,
                        ErrorType = e.Severity.ToString(),
                        Line = e.Exception.LineNumber,
                        Column = e.Exception.LinePosition,
                        Message = e.Message
                    }) ;

                XmlReader xmlFileReader = XmlReader.Create(xmlFile.OpenReadStream(), settings);
                while (xmlFileReader.Read())
                { }

                ViewBag.XmlFileName = xmlFile.FileName;
                ViewBag.SchemaFileName = schemaFile.FileName;

                return View("ValidationResult", validationResults);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
