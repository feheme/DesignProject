using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(booking => booking.Name)
              .NotEmpty().WithMessage("İsim alanı boş olamaz.");

            RuleFor(booking => booking.Mail)
                .NotEmpty().WithMessage("E-posta alanı boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi girin.");

            RuleFor(booking => booking.CheckIn)
                .NotEmpty().WithMessage("Giriş tarihi boş olamaz.")
                .Must(BeFutureDate).WithMessage("Geçerli bir ileri tarih girin.")
                .Must(BeWithin1YearFromToday).WithMessage("Giriş tarihi en fazla 1 yıl sonrasını kabul eder.");

            RuleFor(booking => booking.CheckOut)
                .NotEmpty().WithMessage("Çıkış tarihi boş olamaz.")
                .Must(BeFutureDate).WithMessage("Geçerli bir ileri tarih girin.")

                .Must((booking, checkout) => BeWithin1MonthFromCheckIn(checkout, booking)).WithMessage("Çıkış tarihi giriş tarihinden en fazla 1 ay sonra olmalıdır.")
                .GreaterThan(booking => booking.CheckIn).WithMessage("Çıkış tarihi giriş tarihinden sonra olmalıdır.");

            RuleFor(booking => booking.AdultCount)
                .NotEmpty().WithMessage("Yetişkin sayısı boş olamaz.")
                .Must(BeValidInteger).WithMessage("Geçerli bir sayı girin.");

           

            RuleFor(booking => booking.RoomName)
                .NotEmpty().WithMessage("Oda adı boş olamaz.");

            RuleFor(booking => booking.SpecialRequest)
                .MaximumLength(100).WithMessage("Özel istek 100 karakterden fazla olamaz.");
        }

        private bool BeFutureDate(DateTime date)
        {
            return date >= DateTime.Today;
        }

        private bool BeWithin100Years(DateTime date)
        {
            return date <= DateTime.Today.AddYears(100);
        }

        private bool BeWithin1YearFromToday(DateTime date)
        {
            return date >= DateTime.Today && date <= DateTime.Today.AddYears(1);
        }

        private bool BeWithin1MonthFromCheckIn(DateTime checkout, Booking booking)
        {
            DateTime checkinWithOneMonth = booking.CheckIn.AddMonths(1);
            return checkout <= checkinWithOneMonth;
        }

        private bool BeValidInteger(string value)
        {
            return int.TryParse(value, out _);
        }
    }
}
