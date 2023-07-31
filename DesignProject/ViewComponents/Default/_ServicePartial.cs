using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DesignProject.ViewComponents.Default
{
    public class _ServicePartial : ViewComponent
    {
        private readonly IServiceService _serviceService;

        public _ServicePartial(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _serviceService.TGetList();
            return View(values);
        }
    }
}
