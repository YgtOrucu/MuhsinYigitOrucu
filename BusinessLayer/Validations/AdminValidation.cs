using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class AdminValidation : AbstractValidator<Admin>
    {
        public AdminValidation()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Ad ve Soyad")).
                MaximumLength(25).WithMessage(ValidationMessages.MaxLength(25)).
                Matches("^[a-zA-ZçÇğĞıİöÖşŞüÜ ]+$").
                WithMessage(ValidationMessages.OnlyLetters("Ad Soyad"));

            RuleFor(x => x.MailAddress).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Mail")).
                MaximumLength(25).WithMessage(ValidationMessages.MaxLength(25)).
                MinimumLength(12).WithMessage(ValidationMessages.MinLength(12)).
                Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage(ValidationMessages.OnlyLetters("Mail"));

            RuleFor(x => x.Password).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Şifre")).
                MaximumLength(65).WithMessage(ValidationMessages.MaxLength(65));
        }
    }
}
