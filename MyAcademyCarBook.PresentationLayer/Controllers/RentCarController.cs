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


            var values = _carService.TGetListAll();

            return View(values);

        }
    }
}
