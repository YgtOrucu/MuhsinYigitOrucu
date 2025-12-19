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
            RuleFor(x=>x.MailAddress).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Mail")).
                MaximumLength(25).WithMessage(ValidationMessages.MaxLength(25)).
                MinimumLength(12).WithMessage(ValidationMessages.MinLength(12)).
                Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage(ValidationMessages.OnlyLetters("Mail"));

            RuleFor(x => x.Password).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Şifre")).
                MaximumLength(15).WithMessage(ValidationMessages.MaxLength(15));
        }
    }
}
