using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;
using MyAcademyCarBook.PresentationLayer.Models;
using System.Diagnostics;
using System.Text.Json;

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
            var cars = _carService.TGetAllCarsWithBrands();
            var brandList = cars.Select(x => x.Brand.BrandName).Distinct().ToList();
            IEnumerable<SelectListItem> models = (from x in brandList
                                                  select new SelectListItem
                                                  {
                                                      Text = x,
                                                      Value = x
                                                  }).ToList();
           ViewBag.cars = models;
            var gasList = cars.Select(x => x.GasType).Distinct().ToList();
            IEnumerable<SelectListItem> gasTypes = (from x in gasList
                                                    select new SelectListItem
                                                    {
                                                        Text = x,
                                                        Value = x,

                                                    }).ToList();

            ViewBag.gas = gasTypes;

            var geatList = cars.Select(x => x.GeatType).Distinct().ToList();
            IEnumerable<SelectListItem> geatTypes = (from x in geatList
                                                     select new SelectListItem
                                                     {
                                                         Text = x,
                                                         Value = x,

                                                     }).ToList();

            ViewBag.geat = geatTypes;
            return View();
        }

        [HttpGet]
        public PartialViewResult FilterCars()
        {
            var cars = _carService.TGetAllCarsWithBrands();
            var brandList = cars.Select(x => x.Brand.BrandName).Distinct().ToList();
            IEnumerable<SelectListItem> models = (from x in brandList
                                                  select new SelectListItem
                                                  {
                                                      Text = x,
                                                      Value = x
                                                  }).ToList();
            ViewBag.cars = models;
            var gasList = cars.Select(x => x.GasType).Distinct().ToList();
            IEnumerable<SelectListItem> gasTypes = (from x in gasList
                                                    select new SelectListItem
                                                    {
                                                        Text = x,
                                                        Value = x,

                                                    }).ToList();

            ViewBag.gas = gasTypes;

            var geatList = cars.Select(x => x.GeatType).Distinct().ToList();
            IEnumerable<SelectListItem> geatTypes = (from x in geatList
                                                     select new SelectListItem
                                                     {
                                                         Text = x,
                                                         Value = x,

                                                     }).ToList();

            ViewBag.geat = geatTypes;
            return PartialView();
        }

        [HttpPost]
        public IActionResult FilterCars(CarViewModel car)
        {
            ViewData["model"] = car.Brand;
            ViewData["year"] = car.Year;
            ViewData["gasType"] = car.GasType;
            ViewData["geatType"] = car.GeatType;

            var values = _carService.TGetAllCarsWithBrands();

            if (!string.IsNullOrEmpty(car.Brand) || car.Year != null || !string.IsNullOrEmpty(car.GasType) || !string.IsNullOrEmpty(car.GeatType))
            {
                var lowerCaseModel = car.Brand.ToLower();
                var lowerCaseGasType = car.GasType.ToLower();
                var lowerCaseGearType = car.GeatType.ToLower();
                values = values.Where(x => x.Brand.BrandName.ToLower().Contains(lowerCaseModel) && x.Year >= car.Year && x.GasType.ToLower() == lowerCaseGasType && x.GeatType.ToLower() == lowerCaseGearType).ToList();

                TempData["filteredCars"] = JsonSerializer.Serialize(values);
                TempData["brandName"] = car.Brand;

                return RedirectToAction("Index", "RentCar");
            }

            return RedirectToAction("Index");
        }
    }
}



       