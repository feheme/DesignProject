using Microsoft.AspNetCore.Mvc;

namespace DesignProject.ViewComponents.Default
{
    public class _ReservationPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
