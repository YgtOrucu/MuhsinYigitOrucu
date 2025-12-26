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

            RuleFor(x => x.About).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Hakkımda")).
                MaximumLength(150).WithMessage(ValidationMessages.MaxLength(150));

            RuleFor(x => x.Address).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Adres")).
               MaximumLength(200).WithMessage(ValidationMessages.MaxLength(200));

            RuleFor(x => x.Phone).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Telefon")).
               MaximumLength(30).WithMessage(ValidationMessages.MaxLength(30));

            RuleFor(x => x.Image).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Resim")).
               MaximumLength(100).WithMessage(ValidationMessages.MaxLength(100));

            RuleFor(x => x.MailAddress).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Mail")).
                MaximumLength(25).WithMessage(ValidationMessages.MaxLength(25)).
                MinimumLength(12).WithMessage(ValidationMessages.MinLength(12)).
                Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage(ValidationMessages.OnlyLetters("Mail"));

            RuleFor(x => x.Password).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Şifre")).
                MaximumLength(65).WithMessage(ValidationMessages.MaxLength(65));
        }
    }
}
