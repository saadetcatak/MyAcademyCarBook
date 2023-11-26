using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;
using X.PagedList;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarDetailService _carDetailService;

        public CarController(ICarService carService, ICarDetailService carDetailService)
        {
            _carService = carService;
            _carDetailService = carDetailService;
        }

        public IActionResult Index()
        {
            var values = _carService.TGetListAll();
            return View(values);
        }
        public IActionResult Index2()
        {
            var values = _carService.TGetAllCarsWithBrands();
            return View(values);
        }

        public IActionResult CarList(int page=1)
        {
            ViewBag.title1 = "Araç Listesi";
            ViewBag.title2 = "Sizin İçin Araç Listemiz";
            var result = _carService.TGetAllCarsWithBrands();

            var values = result.ToPagedList(page, 3);
            return View(values);
        
        }

        public IActionResult CarDetail(int id)
        {
            ViewBag.title1 = "Araç Detayları";
            ViewBag.title2 = "Son Araç Detayları";
            ViewBag.i = id;
            var value=_carDetailService.TGetCarDetailByCarID(id);
            ViewBag.v = value.Description;
            return View();
        }
        public PartialViewResult MakeComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }

    }
}
