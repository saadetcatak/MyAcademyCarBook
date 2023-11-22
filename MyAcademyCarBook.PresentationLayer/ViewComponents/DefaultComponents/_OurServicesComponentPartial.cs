using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using System.Runtime.CompilerServices;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.DefaultComponents
{
    public class _OurServicesComponentPartial:ViewComponent
    { private readonly IServiceService _serviceService;

        public _OurServicesComponentPartial(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _serviceService.TGetListAll();
            return View(values);
        }
    }
}
