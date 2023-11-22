using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.DefaultComponents
{
    public class _CarByFiltersComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
