using GemBoxDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace GemBoxDemo.Controllers
{
    public class GeneratingController : Controller
    {
        public IActionResult Index()
        {
            var model = new GeneratingModel();
            return View(model);
        }
    }
}
