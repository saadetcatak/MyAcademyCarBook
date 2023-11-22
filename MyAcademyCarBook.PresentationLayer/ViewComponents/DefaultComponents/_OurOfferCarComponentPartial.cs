using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.DefaultComponents
{
    public class _OurOfferCarComponentPartial:ViewComponent
    {
        private readonly ICarService _carService;

        public _OurOfferCarComponentPartial(ICarService carService)
        {
            _carService = carService;
        }

        public IViewComponentResult Invoke()
        {
            var values=_carService.TGetListAll();
            return View(values);
        }
    }
}
