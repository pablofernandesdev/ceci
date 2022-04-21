using Ceci.Domain.DTO.Role;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceci.Service.Validators.Role
{
    public class RoleAddValidator : AbstractValidator<RoleAddDTO>
    {
        public RoleAddValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter the name role.")
                .NotNull().WithMessage("Please enter the name role.");
        }
    }
}