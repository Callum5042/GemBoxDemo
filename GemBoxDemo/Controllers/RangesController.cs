using GemBoxDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace GemBoxDemo.Controllers
{
    public class RangesController : Controller
    {
        public IActionResult Index()
        {
            var model = GenerateModel();
            return View(model);
        }

        private static RangesModel GenerateModel()
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
