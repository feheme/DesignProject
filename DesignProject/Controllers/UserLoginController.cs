using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DesignProject.Models;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesignProject.Controllers
{
    [AllowAnonymous]
    public class UserLoginController : Controller
    {

        private readonly IBookingService _bookingService;

        public UserLoginController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }


        [HttpGet]
        public IActionResult Login()
        {

            var errorMessages = TempData["ErrorMessages"];

            if (errorMessages != null)
            {
                ViewBag.ErrorMessages = errorMessages;
            }
            return View();
        }
        

        [HttpPost]
        public IActionResult Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // E-posta ve numarayı kullanarak giriş işlemini kontrol edebilirsiniz
                // İlgili doğrulama veya iş mantığını burada gerçekleştirebilirsiniz

                if (IsValidLogin(model.Email, model.PhoneNumber, model.Name))
                {
                    // Giriş başarılı ise istediğiniz işlemi yapabilirsiniz
                    int userId = GetUserId(model.Email, model.PhoneNumber, model.Name);

                    TempData["userId"] = userId;

                    return RedirectToAction("UpdateBooking", "UserLogin"); // Örneğin ana sayfaya yönlendirme
                }
                else
                {
                    ModelState.AddModelError("", "Geçersiz e-posta veya numara");
                    
                }
            }

            return View();
        }

        private bool IsValidLogin(string email, string phoneNumber, string UName)
        {
            using (var dbContext = new Context()) // Veritabanı bağlantısını oluşturun
            {
                var user = dbContext.Bookings.FirstOrDefault(u => u.Mail == email && u.PhoneNumber == phoneNumber && u.Name == UName);

                if (user != null)
                {


                    // Kullanıcı doğrulandı
                    return true;
                }
            }

            return false;
        }

        private int GetUserId(string email, string phoneNumber, string UName)
        {
            using (var dbContext = new Context()) // Veritabanı bağlantısını oluşturun
            {
                var user = dbContext.Bookings.FirstOrDefault(u => u.Mail == email && u.PhoneNumber == phoneNumber && u.Name == UName);

                if (user != null)
                {
                    // Kullanıcı doğrulandı
                    return user.BookingID;
                }
            }

            return -1; // Kullanıcı bulunamadıysa veya hata varsa -1 döndürülebilir
        }



        [HttpGet]
        public IActionResult UpdateBooking()
        {
            var user = (int) TempData["userId"];
            var value = _bookingService.TGetByID(user);
            
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateBooking(Booking booking)
        {
            BookingValidator validationRules = new BookingValidator();
            ValidationResult result = validationRules.Validate(booking);

            if (result.IsValid)
            {
                booking.Status = "Onay Bekliyor";
                _bookingService.TUpdate(booking);
                TempData["SuccessMessage"] = "Değişiklikleriniz sisteme kaydedildi. Lütfen admin'in onay vermesini bekleyiniz.";

                return RedirectToAction("Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                TempData["ErrorMessages"] = result.Errors.Select(e => e.ErrorMessage).ToList();



            }
            return RedirectToAction("Login");




        }
    }
}
