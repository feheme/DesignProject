using Microsoft.AspNetCore.Mvc;

namespace DesignProject.ViewComponents.Default
{
    public class _NavbarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
