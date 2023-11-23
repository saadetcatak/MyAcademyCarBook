using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.AboutComponents
{
    public class _OurTeamAboutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
