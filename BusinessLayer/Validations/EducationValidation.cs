using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer.Validations.AboutValidations;

namespace BusinessLayer.Validations
{
    public class EducationValidation : AbstractValidator<Education>
    {
        public EducationValidation()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Başlık")).
               MaximumLength(25).WithMessage(ValidationMessages.MaxLength(25)).
               Matches("^[a-zA-ZçÇğĞıİöÖşŞüÜ ]+$").WithMessage(ValidationMessages.OnlyLetters("Başlık"));

            RuleFor(x => x.SubHeadingName).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Alt Başlık")).
                MaximumLength(25).WithMessage(ValidationMessages.MaxLength(25)).
                Matches("^[a-zA-ZçÇğĞıİöÖşŞüÜ ]+$").WithMessage(ValidationMessages.OnlyLetters("Alt Başlık"));

            RuleFor(x => x.Description).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Açıklama")).
               MaximumLength(250).WithMessage(ValidationMessages.MaxLength(250)).
               Matches("^[a-zA-ZçÇğĞıİöÖşŞüÜ ]+$").WithMessage(ValidationMessages.OnlyLetters("Açıklama"));

            RuleFor(x => x.SubHeadingName1).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Alt Başlık")).
               MaximumLength(25).WithMessage(ValidationMessages.MaxLength(25)).
               Matches("^[a-zA-ZçÇğĞıİöÖşŞüÜ ]+$").WithMessage(ValidationMessages.OnlyLetters("Alt Başlık"));

            RuleFor(x => x.Date).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Tarih")).
               MaximumLength(25).WithMessage(ValidationMessages.MaxLength(25)).
               Matches("^[a-zA-ZçÇğĞıİöÖşŞüÜ ]+$").WithMessage(ValidationMessages.OnlyLetters("Tarih"));
        }
    }
}
