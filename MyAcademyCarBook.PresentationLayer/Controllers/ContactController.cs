using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.EntityLayer.Concrete;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMessageService _messageService;

        public ContactController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            ViewBag.title1 = "İletişim";
            ViewBag.title2 = "Bizimle iletişime geçmek için mesaj gönderebilirsiniz.";
            return View();
        }

        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {

            if (message.Name != null && message.Subject != null && message.Email != null && message.MessageContent != null)
            {

                ViewBag.message = "Model is valid";
                _messageService.TInsert(message);
                return RedirectToAction("Index");
            }

            return RedirectToAction("SendMessage");
        }
    }
}
