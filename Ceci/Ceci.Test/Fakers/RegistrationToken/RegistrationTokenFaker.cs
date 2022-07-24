using Bogus;
using Ceci.Test.Fakers.User;

namespace Ceci.Test.Fakers.RegistrationToken
{
    public class RegistrationTokenFaker
    {
        public static Faker<Ceci.Domain.Entities.RegistrationToken> RegistrationTokenEntity()
        {
            return new Faker<Ceci.Domain.Entities.RegistrationToken>()
                .CustomInstantiator(p => new Ceci.Domain.Entities.RegistrationToken
                {
                    Active = true,
                    UserId = p.Random.Int(),
                    Id = p.Random.Int(),
                    RegistrationDate = p.Date.Recent(),
                    Token = p.Random.String2(30),
                    User = UserFaker.UserEntity().Generate()
                });
        }
    }
}
