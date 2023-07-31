using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;

namespace DesignProject.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IMessageCategoryService _messageCategoryService;
        private readonly IContactService _contactService;

        public ContactController(IMessageCategoryService messageCategoryService, IContactService contactService)
        {
            _messageCategoryService = messageCategoryService;
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values = _messageCategoryService.TGetList();
           
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SendMessage(Contact contact)
        {


            ContactValidator validationRules = new ContactValidator();
            ValidationResult result = validationRules.Validate(contact);


            if (result.IsValid)
            {
                contact.Date = DateTime.Parse(DateTime.Now.ToString());

                _contactService.TInsert(contact);

                return RedirectToAction("Index", "Default");


            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View("Index");



            
        }

    }
}
