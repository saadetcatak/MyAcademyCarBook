using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;
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
            var cars = _carService.TGetListAll();

            IEnumerable<SelectListItem> models = (from x in cars
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CarName,
                                                      Value = x.CarName,

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
            var cars = _carService.TGetListAll();

            IEnumerable<SelectListItem> models = (from x in cars
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CarName,
                                                      Value = x.CarName,

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
        public IActionResult FilterCars(Car car)
        {
            ViewData["model"] = car.CarName;
            ViewData["year"] = car.Year;
            ViewData["gasType"] = car.GasType;
            ViewData["geatType"] = car.GeatType;


            var values = _carService.TGetListAll();




            if (!string.IsNullOrEmpty(car.CarName) || car.Year != null || !string.IsNullOrEmpty(car.GasType) || !string.IsNullOrEmpty(car.GeatType))
            {


                var lowerCaseModel = car.CarName.ToLower();
                var lowerCaseGasType = car.GasType.ToLower();
                var lowerCaseGearType = car.GeatType.ToLower();
                values = values.Where(x => x.CarName.ToLower().Contains(lowerCaseModel) && x.Year >= car.Year && x.GasType.ToLower() == lowerCaseGasType && x.GeatType.ToLower() == lowerCaseGearType).ToList();


                TempData["filteredCars"] = JsonSerializer.Serialize(values);
                return RedirectToAction("Index", "RentCar");





            }

            return RedirectToAction("Index");
        }
    }
}



        //public IActionResult CarListFilter(string Model,string GeatType,int Year,string BrandName)
        //{
        //    var cars = _carService.TGetCarByFilters(Model, GeatType, Year, BrandName);
        //    ViewBag.Model = Model;
        //    ViewBag.GeatType= GeatType;
        //    ViewBag.BrandName= BrandName;
        //    ViewBag.Year = Year;
        //    return View(cars);
        //}
    