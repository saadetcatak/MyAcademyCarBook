using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.DashboardComponents
{
    public class _TeamDetailComponentsPartial:ViewComponent
    {
        private readonly ITeamService _teamService;

        public _TeamDetailComponentsPartial(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _teamService.TGetListAll();
            return View(values);  
        }

    }
}
