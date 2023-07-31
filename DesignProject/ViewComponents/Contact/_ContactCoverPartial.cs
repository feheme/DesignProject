using Microsoft.AspNetCore.Mvc;

namespace DesignProject.ViewComponents.Contact
{
    public class _ContactCoverPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
