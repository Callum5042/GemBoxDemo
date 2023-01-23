﻿using GemBoxDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using GemBox.Document;

namespace GemBoxDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Download()
        {
            var document = new DocumentModel();

            var section = new Section(document);
            document.Sections.Add(section);

            var paragraph = new Paragraph(document);
            section.Blocks.Add(paragraph);

            var run = new Run(document, "Hello World!");
            paragraph.Inlines.Add(run);

            using var stream = new MemoryStream();
            // document.Save("Hello World.docx");
            document.Save(stream, SaveOptions.DocxDefault);

            return File(stream.ToArray(), SaveOptions.DocxDefault.ContentType, "GemBoxDemo.docx");
        }
    }
}