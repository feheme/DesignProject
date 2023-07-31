using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DesignProject.ViewComponents.Dashboard
{
    public class _DashboardLast6Bookings: ViewComponent
    {
        private readonly IBookingService _bookingService;

        public _DashboardLast6Bookings(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _bookingService.TLast6Bookings();
            return View(result);
        }
    }
}
