using Ceci.Domain.DTO.User;
using FluentValidation;

namespace Ceci.Service.Validators.User
{
    public class UserLoggedUpdateValidator : AbstractValidator<UserLoggedUpdateDTO>
    {
        public UserLoggedUpdateValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter the name.")
                .NotNull().WithMessage("Please enter the name.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Please enter the email user.")
                .NotNull().WithMessage("Please enter the email user.")
                .EmailAddress().WithMessage("Please enter the valid email user.");
        }
    }
}
