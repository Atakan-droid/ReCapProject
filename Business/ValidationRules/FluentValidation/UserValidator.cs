using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.Password).MinimumLength(6);
            RuleFor(p => p.Email).Must(Inside);
            RuleFor(p => p.LastName).MinimumLength(3).When(p => p.FirstName.Length == 3);

        }

        private bool Inside(string arg)
        {
            return arg.Contains("@");
        }
    }
}
