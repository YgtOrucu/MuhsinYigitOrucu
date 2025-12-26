using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class ExperienceValidation : AbstractValidator<Experience>
    {
        public ExperienceValidation()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage(ValidationMessages.NotEmpty("Şirket Adı"))
                .MinimumLength(3).WithMessage(ValidationMessages.MinLength(3))
                .MaximumLength(30).WithMessage(ValidationMessages.MaxLength(30));

            RuleFor(x => x.JobName)
                .NotEmpty().WithMessage(ValidationMessages.NotEmpty("İş Adı"))
                .MinimumLength(5).WithMessage(ValidationMessages.MinLength(5))
                .MaximumLength(40).WithMessage(ValidationMessages.MaxLength(40))
                .Matches("^[a-zA-ZçÇğĞıİöÖşŞüÜ ]+$")
                .WithMessage(ValidationMessages.OnlyLetters("İş Adı"));

            RuleFor(x => x.Place)
                .NotEmpty().WithMessage(ValidationMessages.NotEmpty("Yer"))
                .MinimumLength(5).WithMessage(ValidationMessages.MinLength(5))
                .MaximumLength(25).WithMessage(ValidationMessages.MaxLength(25));

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage(ValidationMessages.NotEmpty("Tarih"))
                .MinimumLength(5).WithMessage(ValidationMessages.MinLength(5))
                .MaximumLength(50).WithMessage(ValidationMessages.MaxLength(50));

            RuleFor(x => x.Description)
               .NotEmpty().WithMessage(ValidationMessages.NotEmpty("Açıklama"))
               .MinimumLength(5).WithMessage(ValidationMessages.MinLength(5));

            RuleFor(x => x.Technologies)
                 .NotEmpty().WithMessage(ValidationMessages.NotEmpty("Teknoloji"))
                 .MinimumLength(5).WithMessage(ValidationMessages.MinLength(5));
        }
    }
}
