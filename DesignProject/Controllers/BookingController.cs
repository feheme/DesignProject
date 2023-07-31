using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesignProject.Controllers
{
    [AllowAnonymous]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;

        public BookingController(IBookingService bookingService, IRoomService roomService)
        {
            _bookingService = bookingService;
            _roomService = roomService;
        }

        public IActionResult Index()
        {


            var errorMessages = TempData["ErrorMessages"];

            if (errorMessages != null)
            {
                ViewBag.ErrorMessages = errorMessages;
            }

            var values = _roomService.TGetList();


            var filteredValues = values.Where(x => x.RoomCount > 0).ToList();


            List<SelectListItem> values2 = filteredValues.Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.Title,             


            }).ToList();

          

            ViewBag.v = values2;

            return View();
            
        }

        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {

            BookingValidator validationRules = new BookingValidator();
            ValidationResult result = validationRules.Validate(booking);


            if (result.IsValid)
            {
                booking.Status = "Onay Bekliyor";     

                _bookingService.TInsert(booking);


                var dbContext = new Context(); // Veritabanı bağlantısı oluşturulmalı

                // Detail bölümündeki ilgili öğeyi bul
                var detailItem = dbContext.Rooms.FirstOrDefault(x => x.Title == booking.RoomName);
                if (detailItem != null)
                {
                    detailItem.RoomCount--; // Total değerini azalt
                    dbContext.Update(detailItem); // Güncelleme işlemi
                    dbContext.SaveChangesAsync(); // Değişiklikleri kaydet
                }
                TempData["SuccessMessage"] = "Rezervasyon İşlemi Başarıyla Tamamlandı. Lütfen Mailinizi Kontrol Ediniz.";
                return RedirectToAction("Index");


            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                TempData["ErrorMessages"] = result.Errors.Select(e => e.ErrorMessage).ToList();

            }
            return RedirectToAction("Index");




        }
    }
}
