using GemBox.Document;
using GemBoxDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace GemBoxDemo.Controllers
{
    public class EncryptionController : Controller
    {
        public IActionResult Index()
        {
            var model = new EncryptionModel();
            return View(model);
        }

        public IActionResult Download(EncryptionModel model)
        {
            // Set License
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            // Create document
            var document = new DocumentModel();

            // Paragraph section
            var section = new Section(document);
            document.Sections.Add(section);

            // Paragraph
            var paragraph = new Paragraph(document, model.Content);
            section.Blocks.Add(paragraph);

            // Save options
            var options = new PdfSaveOptions()
            {
                DocumentOpenPassword = model.Password,
                Permissions = PdfPermissions.None
            };

            // Save
            using var stream = new MemoryStream();
            document.Save(stream, options);
            return File(stream.ToArray(), SaveOptions.PdfDefault.ContentType, "GemBoxEncryptionDemo.pdf");
        }
    }
}
