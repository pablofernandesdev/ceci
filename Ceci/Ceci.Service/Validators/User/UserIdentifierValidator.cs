using Ceci.Domain.DTO.User;
using Ceci.Domain.Interfaces.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceci.Service.Validators.User
{
    public class UserIdentifierValidator : AbstractValidator<UserIdentifierDTO>
    {
        public UserIdentifierValidator()
        {
            RuleFor(c => c.UserId)
                .NotEmpty().WithMessage("Please enter the identifier user.")
                .NotNull().WithMessage("Please enter the identifier user.");
        }
    }
}
