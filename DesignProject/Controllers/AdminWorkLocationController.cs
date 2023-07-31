using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DesignProject.Controllers
{
    public class AdminWorkLocationController : Controller
    {
        private readonly IWorkLocationService _workLocationService;

        public AdminWorkLocationController(IWorkLocationService workLocationService)
        {
            _workLocationService = workLocationService;
        }

        public IActionResult Index()
        {
            var values = _workLocationService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddWorkLocation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddWorkLocation(WorkLocation workLocation)
        {
            _workLocationService.TInsert(workLocation);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteWorkLocation(int id)
        {
            var values = _workLocationService.TGetByID(id);
            _workLocationService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateWorkLocation(int id)
        {
            var values = _workLocationService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateWorkLocation(WorkLocation workLocation)
        {
            _workLocationService.TUpdate(workLocation);
            return RedirectToAction("Index");
        }
    }
}
