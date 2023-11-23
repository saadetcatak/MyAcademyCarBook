using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.ViewComponents.ContactComponents
{
    public class _ContactInfoComponentsPartial : ViewComponent
    {
        private readonly IContactService _contactService;

        public _ContactInfoComponentsPartial(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _contactService.TGetListAll();
            return View(values); 
        }
    }
}
