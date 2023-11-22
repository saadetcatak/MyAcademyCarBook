using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ICarService _carService;

        public DefaultController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CarListFilter(string Model,string GeatType,int Year,string BrandName)
        {
            var cars = _carService.TGetCarByFilters(Model, GeatType, Year, BrandName);
            ViewBag.Model = Model;
            ViewBag.GeatType= GeatType;
            ViewBag.BrandName= BrandName;
            ViewBag.Year = Year;
            return View(cars);
        }
    }
}
