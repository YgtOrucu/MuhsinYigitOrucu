using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class CheckAdminForLoginValidation : AbstractValidator<Admin>
    {
        public CheckAdminForLoginValidation()
        {
           
            RuleFor(x => x.MailAddress).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Mail")).
                MaximumLength(25).WithMessage(ValidationMessages.MaxLength(25)).
                MinimumLength(12).WithMessage(ValidationMessages.MinLength(12)).
                Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage(ValidationMessages.OnlyMail("Mail"));

            RuleFor(x => x.Password).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Şifre")).
               MaximumLength(65).WithMessage(ValidationMessages.MaxLength(15)).
               MinimumLength(5).WithMessage(ValidationMessages.MinLength(5)).
               Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]+$").WithMessage(ValidationMessages.ForPassword("Şifre"));
        }
    }
}
