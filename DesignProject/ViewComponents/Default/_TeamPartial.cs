using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DesignProject.ViewComponents.Default
{
    public class _TeamPartial : ViewComponent
    {
        private readonly IStaffService _staffService;

        public _TeamPartial(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _staffService.TGetList();
            return View(values);
        }
    }
}
