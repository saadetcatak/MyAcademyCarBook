using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;
using System.Text.Json;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class RentCarController : Controller
    {
        private readonly ICarService _carService;

        public RentCarController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {
            if (TempData["filteredCars"] != null)
            {
                var cars = TempData["filteredCars"];
                var data = JsonSerializer.Deserialize<List<Car>>(cars.ToString());
                return View(data);
            }
            ViewBag.title1 = "Araç Kiralama";
            ViewBag.title2 = "Her Bütçeye Uygun Araçlar ve Ödeme Kolaylığıyla Hizmetinizdeyiz";

            var values = _carService.TGetAllCarsWithBrands();

            return View(values);

        }
    }
}
