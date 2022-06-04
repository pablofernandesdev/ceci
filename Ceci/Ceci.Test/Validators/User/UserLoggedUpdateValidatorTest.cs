using Ceci.Domain.DTO.Register;
using Ceci.Domain.DTO.User;
using Ceci.Service.Validators.User;
using Ceci.Test.Fakers.User;
using FluentValidation.TestHelper;
using Xunit;

namespace Ceci.Test.Validators.User
{
    public class UserLoggedUpdateValidatorTest
    {
        private readonly UserLoggedUpdateValidator _validator;

        public UserLoggedUpdateValidatorTest()
        {
            _validator = new UserLoggedUpdateValidator();
        }

        [Fact]
        public void There_should_be_an_error_when_properties_are_null()
        {
            //Arrange
            var model = new UserLoggedUpdateDTO();

            //act
            var result = _validator.TestValidate(model);

            //assert
            result.ShouldHaveValidationErrorFor(user => user.Email);
            result.ShouldHaveValidationErrorFor(user => user.Name);
        }

        [Fact]
        public void There_should_not_be_an_error_for_the_properties()
        {
            //Arrange
            var model = UserFaker.UserLoggedUpdateDTO().Generate();

            //act
            var result = _validator.TestValidate(model);

            //assert
            result.ShouldNotHaveValidationErrorFor(user => user.Email);
            result.ShouldNotHaveValidationErrorFor(user => user.Name);
        }
    }
}
