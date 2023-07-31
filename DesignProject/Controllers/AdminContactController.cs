using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace DesignProject.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly ISendMessageService _sendMessageService;

        public AdminContactController(IContactService contactService, ISendMessageService sendMessageService)
        {
            _contactService = contactService;
            _sendMessageService = sendMessageService;
        }

        public IActionResult Inbox()
        {
            var responseMessage = _contactService.TGetList();
            var responseMessage2 = _contactService.TGetContactCount();
            var responseMessage3 = _sendMessageService.TGetSendMessageCount();

            ViewBag.contactCount = responseMessage2;
            ViewBag.sendMessageCount = responseMessage3;


            return View(responseMessage);
        }

        public IActionResult SendBox()
        {
            var values = _sendMessageService.TGetList();

            return View(values);
        }
        [HttpGet]
        public PartialViewResult AddSendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddSendMessage(SendMessage sendMessage)
        {
            sendMessage.SenderMail = "admin@gmail.com";
            sendMessage.SenderName = "feheme";
            sendMessage.Date = DateTime.Parse(DateTime.Now.ToShortDateString());

            _sendMessageService.TInsert(sendMessage);
            return RedirectToAction("SendBox");
        }
        public PartialViewResult SideBarAdminContactPartial()
        {
            return PartialView();
        }
        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }

        public IActionResult MessageDetailsBySendBox(int id)
        {

            var value = _sendMessageService.TGetByID(id);
            return View(value);

        }

        public IActionResult MessageDetailsByInbox(int id)
        {

            var value = _contactService.TGetByID(id);
            return View(value);


        }
    }
}
