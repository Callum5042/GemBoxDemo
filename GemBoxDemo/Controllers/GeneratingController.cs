using GemBox.Document;
using GemBox.Document.Tables;
using GemBoxDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace GemBoxDemo.Controllers
{
    public class GeneratingController : Controller
    {
        public IActionResult Index()
        {
            var model = new GeneratingModel();
            model.Paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer ultricies non sapien non dictum. Nam sit amet nulla in tellus lobortis tincidunt. Quisque a tellus vitae felis finibus auctor. Fusce vehicula blandit congue. Nulla sagittis justo sit amet lacus commodo ullamcorper. Nulla mollis quam velit, ac feugiat ante porta feugiat. Aliquam dignissim cursus tortor, non dictum purus. Fusce sodales sit amet orci ac fringilla. Nulla diam augue, suscipit in semper et, hendrerit eu ante. Praesent hendrerit, libero et posuere mattis, diam lacus vestibulum augue, nec rhoncus tortor erat in nisl.";

            return View(model);
        }

        public IActionResult Download(GeneratingModel model)
        {
            // Set License
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            // Create document
            var document = new DocumentModel();

            // Paragraph section
            var section = new Section(document);
            document.Sections.Add(section);

            // Title
            var titleStyle = (ParagraphStyle)Style.CreateStyle(StyleTemplateType.Title, document);
            document.Styles.Add(titleStyle);
            section.Blocks.Add(new Paragraph(document, "Generating Document Title") { ParagraphFormat = { Style = titleStyle } });

            // Paragraph
            var paragraph = new Paragraph(document);
            section.Blocks.Add(paragraph);
            paragraph.Inlines.Add(new Run(document, model.Paragraph));

            // Save
            using var stream = new MemoryStream();
            document.Save(stream, SaveOptions.DocxDefault);
            return File(stream.ToArray(), SaveOptions.DocxDefault.ContentType, "GemBoxGeneratingDemo.docx");
        }
    }
}
