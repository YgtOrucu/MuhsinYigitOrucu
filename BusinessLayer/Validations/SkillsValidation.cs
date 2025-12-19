using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class SkillsValidation:AbstractValidator<Skills>
    {
        public SkillsValidation()
        {
            RuleFor(x => x.SkillsName).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Yetenek")).
                MaximumLength(100).WithMessage(ValidationMessages.MaxLength(100)).
                MinimumLength(30).WithMessage(ValidationMessages.MinLength(30));

            RuleFor(x => x.SkillsPercentage).NotEmpty().WithMessage(ValidationMessages.NotEmpty("Yüzde")).
               MaximumLength(3).WithMessage(ValidationMessages.MaxLength(3));
        }
    }
}
