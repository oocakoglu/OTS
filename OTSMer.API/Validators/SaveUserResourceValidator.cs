using FluentValidation;
using OTSMer.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTSMer.API.Validators
{
    public class SaveUserResourceValidator : AbstractValidator<SaveUserDTO>
    {
        public SaveUserResourceValidator()
        {
            RuleFor(a => a.UserName)
              .NotEmpty()
              .MaximumLength(50);

            RuleFor(a => a.Password)
              .NotEmpty()
              .MinimumLength(6)
              .MaximumLength(10);
        }
    }
}
