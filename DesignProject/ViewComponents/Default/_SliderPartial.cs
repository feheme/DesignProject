using Microsoft.AspNetCore.Mvc;

namespace DesignProject.ViewComponents.Default
{
    public class _SliderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
