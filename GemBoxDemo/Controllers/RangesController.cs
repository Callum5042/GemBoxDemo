using GemBox.Document;
using GemBoxDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace GemBoxDemo.Controllers
{
    public class RangesController : Controller
    {
        public IActionResult Index()
        {
            var model = GetModel();
            return View(model);
        }

        public IActionResult Download()
        {
            var model = GetModel();

            // Set License
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            // Load template
            DocumentModel doc = DocumentModel.Load(@"GemBoxMoviesTemplate.docx");

            // Execute mail merge.
            doc.MailMerge.Execute(model);

            // Document type
            var saveOptions = SaveOptions.DocxDefault;
            var filename = $"GemBoxMailMergeDemo.docx";

            // Save
            using var stream = new MemoryStream();
            doc.Save(stream, saveOptions);
            return File(stream.ToArray(), saveOptions.ContentType, filename);
        }

        private static RangesModel GetModel()
        {
            return new RangesModel
            {
                Movies = new List<MovieListModel>()
                {
                    new MovieListModel() { Title = "Interstellar", ReleaseYear = new DateTime(2014, 1, 1) },
                    new MovieListModel() { Title = "The Shawshank Redemption", ReleaseYear = new DateTime(1994, 1, 1) },
                    new MovieListModel() { Title = "The Godfather", ReleaseYear = new DateTime(1972, 1, 1) },
                    new MovieListModel() { Title = "Gladiator", ReleaseYear = new DateTime(2000, 1, 1) },
                    new MovieListModel() { Title = "The Prestige", ReleaseYear = new DateTime(2006, 1, 1) },
                }
            };
        }
    }
}
