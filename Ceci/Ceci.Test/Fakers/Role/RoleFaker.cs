using Bogus;
using Ceci.Domain.DTO.Role;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceci.Test.Fakers.Role
{
    public static class RoleFaker
    {
        public static Faker<Ceci.Domain.Entities.Role> RoleEntity()
        {
            return new Faker<Ceci.Domain.Entities.Role>()
                .CustomInstantiator(p => new Ceci.Domain.Entities.Role
                {
                    Active = true,
                    Id = p.Random.Int(1, 2),
                    Name = p.Random.Word(),
                    RegistrationDate = p.Date.Recent(),
                    User = new List<Domain.Entities.User>()
                });
        }

        public static Faker<RoleAddDTO> RoleAddDTO()
        {
            return new Faker<RoleAddDTO>()
                .CustomInstantiator(p => new RoleAddDTO
                {
                    Name = p.Random.Word(),
                });
        }

        public static Faker<RoleUpdateDTO> RoleUpdateDTO()
        {
            return new Faker<RoleUpdateDTO>()
                .CustomInstantiator(p => new RoleUpdateDTO
                {
                    Name = p.Random.Word(),
                    RoleId = p.Random.Int()
                });
        }

        public static Faker<RoleResultDTO> RoleResultDTO()
        {
            return new Faker<RoleResultDTO>()
                .CustomInstantiator(p => new RoleResultDTO
                {
                    Name = p.Random.Word(),
                    RoleId = p.Random.Int()
                });
        }
    }
}
