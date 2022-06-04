using Ceci.Domain.DTO.Auth;
using Ceci.Domain.Interfaces.Repository;
using FluentValidation;
using System.Threading.Tasks;

namespace Ceci.Service.Validators.Login
{
    public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordDTO>
    {
        private readonly IUnitOfWork _uow;

        public ForgotPasswordValidator(IUnitOfWork uow)
        {
            _uow = uow;

            RuleFor(c => c.Email)
                .EmailAddress()
                .MustAsync(async (email, cancellation) => {
                    return await RegisteredEmail(email);
                }).WithMessage("E-mail not found.");
        }

        private async Task<bool> RegisteredEmail(string email)
        {
            return await _uow.User.GetFirstOrDefaultAsync(x => x.Email.Equals(email)) != null;
        }
    }
}
