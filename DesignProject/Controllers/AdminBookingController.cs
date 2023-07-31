using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace DesignProject.Controllers
{
    
    public class AdminBookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public AdminBookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public IActionResult Index()
        {
            var values = _bookingService.TGetList();
            return View(values);
        }


        public IActionResult ApprovedReservation(int id)
        {

            _bookingService.TBookingStatusChangeApproved(id);
            return RedirectToAction("Index");
        }

        public IActionResult CancelReservation(int id)
        {

            _bookingService.TBookingStatusChangeCancel(id);
            return RedirectToAction("Index");
        }

        public IActionResult WaitReservation(int id)
        {
            _bookingService.TBookingStatusChangeWait(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return RedirectToAction("Index");
        }
    }
}
