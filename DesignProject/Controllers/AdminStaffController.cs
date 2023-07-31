namespace DesignProject.Controllers
{
    using BusinessLayer.Abstract;
    using EntityLayer.Concrete;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    namespace DesignProject.Controllers
    {
        
        public class AdminStaffController : Controller
        {
            private readonly IStaffService _staffService;

            public AdminStaffController(IStaffService staffService)
            {
                _staffService = staffService;
            }

            public IActionResult Index()
            {
                var values = _staffService.TGetList();
                return View(values);
            }
            [HttpGet]
            public IActionResult AddStaff()
            {
                return View();
            }
            [HttpPost]
            public IActionResult AddStaff(Staff staff)
            {
                _staffService.TInsert(staff);
                return RedirectToAction("Index");
            }

            public IActionResult DeleteStaff(int id)
            {
                var values = _staffService.TGetByID(id);
                _staffService.TDelete(values);
                return RedirectToAction("Index");
            }
            [HttpGet]
            public IActionResult UpdateStaff(int id)
            {
                var values = _staffService.TGetByID(id);
                return View(values);
            }
            [HttpPost]
            public IActionResult UpdateStaff(Staff staff)
            {
                _staffService.TUpdate(staff);
                return RedirectToAction("Index");
            }

        }
    }


}
