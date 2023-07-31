using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesignProject.Controllers
{
   
    public class AdminGuestController : Controller
    {
        private readonly IGuestService _guestService;

        public AdminGuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        public IActionResult Index()
        {
            var values = _guestService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddGuest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGuest(Guest guest)
        {
            
            _guestService.TInsert(guest);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteGuest(int id)
        {
            var values = _guestService.TGetByID(id);
            _guestService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateGuest(int id)
        {
            var values = _guestService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateGuest(Guest guest)
        {
            _guestService.TUpdate(guest);
            return RedirectToAction("Index");
        }
    }
}
