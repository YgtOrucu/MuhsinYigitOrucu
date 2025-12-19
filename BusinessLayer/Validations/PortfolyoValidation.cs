using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class PortfolyoValidation : AbstractValidator<Portfolyo>
    {
        public PortfolyoValidation()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Başlık İsim")).
                MaximumLength(25).WithMessage(ValidationMessages.MaxLength(25)).
                MinimumLength(5).WithMessage(ValidationMessages.MinLength(5));

            RuleFor(x => x.Image)
                 .NotEmpty().WithMessage(ValidationMessages.NotEmpty("Resim"));
        }
    }
}
