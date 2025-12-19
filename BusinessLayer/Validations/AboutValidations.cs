using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concreate;
using FluentValidation;

namespace BusinessLayer.Validations
{
    public class AboutValidations : AbstractValidator<About>
    {
        public AboutValidations()
        {
            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage(ValidationMessages.NotEmpty("Ad Soyad"))
                .MinimumLength(5).WithMessage(ValidationMessages.MinLength(5))
                .MaximumLength(25).WithMessage(ValidationMessages.MaxLength(25))
                .Matches("^[a-zA-ZçÇğĞıİöÖşŞüÜ ]+$")
                .WithMessage(ValidationMessages.OnlyLetters("Ad Soyad"));

            RuleFor(x => x.Job)
                .NotEmpty().WithMessage(ValidationMessages.NotEmpty("İş"))
                .MinimumLength(5).WithMessage(ValidationMessages.MinLength(5))
                .MaximumLength(25).WithMessage(ValidationMessages.MaxLength(25))
                .Matches("^[a-zA-ZçÇğĞıİöÖşŞüÜ ]+$")
                .WithMessage(ValidationMessages.OnlyLetters("İş"));

            RuleFor(x => x.ShortDescription)
                .NotEmpty().WithMessage(ValidationMessages.NotEmpty("Kısa Açıklama"))
                .MinimumLength(5).WithMessage(ValidationMessages.MinLength(5))
                .MaximumLength(50).WithMessage(ValidationMessages.MaxLength(50))
                .Matches("^[a-zA-ZçÇğĞıİöÖşŞüÜ ]+$")
                .WithMessage(ValidationMessages.OnlyLetters("Kısa Açıklama"));

            RuleFor(x => x.LongDescription)
                .NotEmpty().WithMessage(ValidationMessages.NotEmpty("Uzun Açıklama"))
                .MinimumLength(5).WithMessage(ValidationMessages.MinLength(5))
                .Matches("^[a-zA-ZçÇğĞıİöÖşŞüÜ ]+$")
                .WithMessage(ValidationMessages.OnlyLetters("Uzun Açıklama"));

            RuleFor(x => x.Image)
                 .NotEmpty().WithMessage(ValidationMessages.NotEmpty("Resim"));
        }
    }
}
