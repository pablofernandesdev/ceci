﻿using Ceci.Domain.DTO.User;
using FluentValidation;

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
