using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Concrete;
using System.Drawing.Design;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.CarDetailComponents
{
    public class _CarDetailCategoryComponentPartial : ViewComponent
    {
       
        private readonly ICarCategoryService _carCategoryService;
        private readonly ICarService _carService;

        public _CarDetailCategoryComponentPartial(ICarCategoryService carCategoryService, ICarService carService = null)
        {
            _carCategoryService = carCategoryService;
            _carService = carService;
        }

        public IViewComponentResult Invoke()
        {
            var values =_carService.TGetCategoryCount();
            return View(values);
        }
    }
}
