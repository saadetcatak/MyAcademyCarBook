using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.DataAccessLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class DashboardController : Controller
    {
       
        public IActionResult Index()
        {
            var _context = new CarBookContext();
            ViewBag.price = _context.Prices.Max(x=>x.PriceValue).ToString();
            ViewBag.brands = _context.Brands.Count();
            ViewBag.car = _context.Cars.Count();
            return View();
        }


    }
}
