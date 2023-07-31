using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DesignProject.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial:ViewComponent
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IAppUserService _appUserService;
        private readonly IRoomService _roomService;

        public _DashboardWidgetPartial(IStaffService staffService, IBookingService bookingService, IAppUserService appUserService, IRoomService roomService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _appUserService = appUserService;
            _roomService = roomService;
        }
        public IViewComponentResult Invoke()
        {
            var stafCount = _staffService.TGetStaffCount();
            var bookingCount = _bookingService.TGetBookingCount();
            var appUserCount = _appUserService.TGetAppUserCount();
            var roomCount = _roomService.TGetRoomCount();

            ViewBag.StaffCount = stafCount;
            ViewBag.BookingCount = bookingCount;
            ViewBag.AppUserCount = appUserCount;
            ViewBag.RoomCount = roomCount;

            return View();
        }
    }
}
