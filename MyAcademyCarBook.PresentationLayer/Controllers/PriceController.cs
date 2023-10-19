using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class PriceController : Controller
    {
        private readonly IPriceService _priceServis;
        private readonly ICarService _carServis;

        public PriceController(IPriceService priceServis, ICarService carServis)
        {
            _priceServis = priceServis;
            _carServis = carServis;
        }

        public IActionResult Index()
        {
            var values = _priceServis.TGetPricesWithCars();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreatePrice()
        {
            List<SelectListItem> values=(from x in _carServis.TGetAllCarsWithBrands()
                                         select new SelectListItem
                                         {
                                             Text=x.Brand.BrandName+" "+x.Model,
                                             Value=x.CarID.ToString()
                                         }).ToList();
            ViewBag.v=values;
            return View();
        }

        [HttpPost]
        public IActionResult CreatePrice(Price price)
        {
            _priceServis.TInsert(price);
            return RedirectToAction("Index");
        }

        public IActionResult DeletePrice(int id)
        {
            var values = _priceServis.TGetByID(id);
            _priceServis.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdatePrice(int id)
        {
            List<SelectListItem> values = (from x in _carServis.TGetAllCarsWithBrands()
                                           select new SelectListItem
                                           {
                                               Text = x.Brand.BrandName + " " + x.Model,
                                               Value = x.CarID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            var value = _priceServis.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdatePrice(Price price)
        {
            _priceServis.TUpdate(price);
            return RedirectToAction("Index");
        }
    }
}
