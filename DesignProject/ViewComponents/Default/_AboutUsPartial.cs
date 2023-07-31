using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DesignProject.ViewComponents.Default
{
    public class _AboutUsPartial : ViewComponent
    {
        private readonly IAboutService _aboutService;
        private readonly IRoomService _roomService;
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;



        public _AboutUsPartial(IAboutService aboutService, IRoomService roomService, IStaffService staffService,IBookingService bookingService)
        {
            _aboutService = aboutService;
            _roomService = roomService;
            _staffService = staffService;
            _bookingService = bookingService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.roomcount = _roomService.TGetRoomCount();
            ViewBag.staffcount =  _staffService.TGetStaffCount();
            ViewBag.bookingcount = _bookingService.TGetBookingCount();
            
            var values = _aboutService.TGetList();
            return View(values);
        }


    }
}
