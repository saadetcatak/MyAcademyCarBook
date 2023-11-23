using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class AboutController : Controller
    {
        private readonly ITeamService _teamService;

        public AboutController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            ViewBag.title1 = "Hakkımızda";
            ViewBag.title2 = "Uzman kadromuzla birlikte yıllardır müşterilerimiz için en doğru yönlendirmeleri yaparak şirketimizin ivmesini hep yukarıya taşıdık";

            var values=_teamService.TGetListAll();

            return View(values);
        }
    }
}
