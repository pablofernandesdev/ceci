using Ceci.Domain.DTO.ValidationCode;
using FluentValidation;

namespace Ceci.Service.Validators.ValidationCode
{
    public class ValidationCodeValidateValidator : AbstractValidator<ValidationCodeValidateDTO>
    {
        public ValidationCodeValidateValidator()
        {
            RuleFor(c => c.Code)
                .NotEmpty().WithMessage("Please enter the code.")
                .NotNull().WithMessage("Please enter the code.");
        }
    }
}