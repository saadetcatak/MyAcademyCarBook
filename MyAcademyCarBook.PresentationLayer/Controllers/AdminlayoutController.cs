using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class AdminlayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
