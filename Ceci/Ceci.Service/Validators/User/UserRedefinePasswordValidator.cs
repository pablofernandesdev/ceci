using Ceci.Domain.DTO.User;
using Ceci.Infra.CrossCutting.Helper;
using FluentValidation;

namespace Ceci.Service.Validators.User
{
    public class UserRedefinePasswordValidator : AbstractValidator<UserRedefinePasswordDTO>
    {
        public UserRedefinePasswordValidator()
        {
            RuleFor(c => c.CurrentPassword)
                .NotEmpty().WithMessage("Please enter the current password.")
                .NotNull().WithMessage("Please enter the current password.");

            When(c => !string.IsNullOrEmpty(c.CurrentPassword), () => {
                RuleFor(c => c.CurrentPassword)
                    .Must(c => StringHelper.IsBase64String(c))
                    .WithMessage("Password must be base64 encoded.");
            });

            RuleFor(c => c.NewPassword)
                .NotEmpty().WithMessage("Please enter the new password.")
                .NotNull().WithMessage("Please enter the new password.");

            When(c => !string.IsNullOrEmpty(c.NewPassword), () => {
                RuleFor(c => c.NewPassword)
                    .Must(c => StringHelper.IsBase64String(c))
                    .WithMessage("Password must be base64 encoded.");
            });
        }
    }
}
