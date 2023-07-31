using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesignProject.Controllers
{
    
    public class AdminAboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AdminAboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var values = _aboutService.TGetList();
            return View(values);
        }        
        
        
        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {

            var values = _aboutService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            AboutValidator validationRules = new AboutValidator();
            ValidationResult result = validationRules.Validate(about);


            if (result.IsValid)
            {
                _aboutService.TUpdate(about);
                return RedirectToAction("Index");


            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();


            
        }
    }
}
