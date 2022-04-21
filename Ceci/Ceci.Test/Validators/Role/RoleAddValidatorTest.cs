using Ceci.Domain.DTO.Role;
using Ceci.Service.Validators.Role;
using Ceci.Test.Fakers.Role;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ceci.Test.Validators.Role
{
    public class RoleAddValidatorTest
    {
        private readonly RoleAddValidator _validator;

        public RoleAddValidatorTest()
        {
            _validator = new RoleAddValidator();
        }

        [Fact]
        public void There_should_be_an_error_when_properties_are_null()
        {
            //Arrange
            var model = new RoleAddDTO();

            //act
            var result = _validator.TestValidate(model);

            //assert
            result.ShouldHaveValidationErrorFor(role => role.Name);
        }

        [Fact]
        public void There_should_not_be_an_error_for_the_properties()
        {
            //Arrange
            var model = RoleFaker.RoleAddDTO().Generate();

            //act
            var result = _validator.TestValidate(model);

            //assert
            result.ShouldNotHaveValidationErrorFor(role => role.Name);
        }
    }
}
