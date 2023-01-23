using GemBox.Document;
using GemBoxDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace GemBoxDemo.Controllers
{
    public class MailMergeController : Controller
    {
        public IActionResult Index()
        {
            var model = new MailMergeModel();
            return View(model);
        }

        public IActionResult Download(MailMergeModel model)
        {
            // Set License
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            // Load template
            var doc = DocumentModel.Load(@"GemBoxDemoTemplate.docx");

            // Execute mail merge.
            doc.MailMerge.Execute(model);

            // Document type
            var saveOptions = GetSaveOptions(model.MailMergeDocType);
            var filename = $"GemBoxDemo.{GetFileExtension(model.MailMergeDocType)}";

            // Save
            using var stream = new MemoryStream();
            doc.Save(stream, saveOptions);
            return File(stream.ToArray(), saveOptions.ContentType, filename);
        }

        private static SaveOptions GetSaveOptions(MailMergeDocType type)
        {
            return type switch
            {
                MailMergeDocType.PDF => SaveOptions.PdfDefault,
                MailMergeDocType.DOCX => SaveOptions.DocxDefault,
                _ => throw new InvalidOperationException(),
            };
        }

        private static string GetFileExtension(MailMergeDocType type)
        {
            return type switch
            {
                MailMergeDocType.PDF => "pdf",
                MailMergeDocType.DOCX => "docx",
                _ => throw new InvalidOperationException(),
            };
        }
    }
}
