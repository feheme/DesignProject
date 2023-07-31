using Microsoft.AspNetCore.Mvc;

namespace DesignProject.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
