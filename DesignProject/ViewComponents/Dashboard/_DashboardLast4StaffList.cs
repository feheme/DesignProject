using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DesignProject.ViewComponents.Dashboard
{
    public class _DashboardLast4StaffList : ViewComponent
    {
        private readonly IStaffService _staffService;

        public _DashboardLast4StaffList(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _staffService.TLast4Staff();
            return View(result);
        }
    }
}
