using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İçerik Boş Geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("İçerik Boş Geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("İçerik Boş Geçilemez");
            RuleFor(x => x.Message).NotEmpty().WithMessage("İçerik Boş Geçilemez");           
            RuleFor(x => x.MessageCategoryID).NotEmpty().WithMessage("İçerik Boş Geçilemez");           
            RuleFor(x => x.Message).MaximumLength(100).WithMessage("İçerik 100 karakterden fazla olamaz");
        }
    }
}
