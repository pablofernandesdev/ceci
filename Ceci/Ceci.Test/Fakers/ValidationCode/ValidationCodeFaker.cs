using Bogus;
using Ceci.Domain.DTO.ValidationCode;
using Ceci.Infra.CrossCutting.Extensions;
using Ceci.Test.Fakers.User;

namespace Ceci.Test.Fakers.ValidationCode
{
    public class ValidationCodeFaker
    {
        public static Faker<Ceci.Domain.Entities.ValidationCode> ValidationCodeEntity()
        {
            return new Faker<Ceci.Domain.Entities.ValidationCode>()
                .CustomInstantiator(p => new Ceci.Domain.Entities.ValidationCode
                {
                    UserId = p.Random.Int(),
                    Active = true,
                    Code = PasswordExtension.EncryptPassword(p.Random.Word()),
                    Expires = p.Date.Future(),
                    Id = p.Random.Int(),
                    RegistrationDate = p.Date.Recent(),
                    User = UserFaker.UserEntity().Generate()               
                });
        }

        public static Faker<ValidationCodeValidateDTO> ValidationCodeValidateDTO()
        {
            return new Faker<ValidationCodeValidateDTO>()
                .CustomInstantiator(p => new ValidationCodeValidateDTO
                {
                    Code = p.Random.Word()
                });
        }
    }
}
