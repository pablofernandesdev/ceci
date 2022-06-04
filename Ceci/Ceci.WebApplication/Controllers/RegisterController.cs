using Ceci.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ceci.Domain.DTO.User;
using Ceci.Domain.DTO.Commons;
using Microsoft.AspNetCore.Authorization;
using Ceci.Domain.DTO.Register;
using Ceci.Domain.DTO.Address;
using System.Collections.Generic;

namespace Ceci.WebApplication.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/register")]
    [ApiController]
    [Authorize(Policy = "Basic")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public RegisterController(IRegisterService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// User self registration
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Success when creating a new user</returns>
        /// <response code="200">Returns success when creating a new item</response>
        /// <response code="400">Returns error if the request fails</response>
        /// <response code="401">Not authorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal server error</response>   
        [AllowAnonymous]
        [HttpPost]
        [Route("self-registration")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResultResponse))]
        public async Task<ActionResult<ResultResponse>> SelfRegistration([FromBody] UserSelfRegistrationDTO model)
        {
            var result = await _userService.SelfRegistrationAsync(model);
            return StatusCode((int)result.StatusCode, result);
        }

        /// <summary>
        /// Update user logged
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Success when updating user logged</returns>
        /// <response code="200">Returns success when updating user logged</response>
        /// <response code="400">Returns error if the request fails</response>
        /// <response code="401">Not authorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal server error</response>   
        [HttpPut]
        [Route("logged-user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResultResponse))]
        public async Task<ActionResult<ResultResponse>> UpdateLoggedInUser([FromBody] UserLoggedUpdateDTO model)
        {
            var result = await _userService.UpdateLoggedUserAsync(model);
            return StatusCode((int)result.StatusCode, result);
        }

        /// <summary>
        /// Get logged in user
        /// </summary>
        /// <returns>Success when get logged in user</returns>
        /// <response code="200">Returns success when get logged in user</response>
        /// <response code="401">Not authorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal server error</response>   
        [HttpGet]
        [Route("logged-user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse<UserResultDTO>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResultResponse))]
        public async Task<ActionResult<ResultResponse<UserResultDTO>>> GetLoggedInUser()
        {
            var result = await _userService.GetLoggedInUserAsync();
            return StatusCode((int)result.StatusCode, result);
        }

        /// <summary>
        /// Redefine user password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Success when redefine user password</returns>
        /// <response code="200">Returns success when redefine user password</response>
        /// <response code="400">Returns error if the request fails</response>
        /// <response code="401">Not authorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal server error</response>   
        [HttpPost]
        [Route("redefine-password")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResultResponse))]
        public async Task<ActionResult<ResultResponse>> RedefinePassword([FromBody] UserRedefinePasswordDTO model)
        {
            var result = await _userService.RedefinePasswordAsync(model);
            return StatusCode((int)result.StatusCode, result);
        }

        /// <summary>
        /// Add logged user address
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Success when add logged user address</returns>
        /// <response code="200">Returns success when add logged user address</response>
        /// <response code="400">Returns error if the request fails</response>
        /// <response code="401">Not authorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal server error</response>   
        [HttpPost]
        [Route("logged-user-address")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResultResponse))]
        public async Task<ActionResult<ResultResponse>> AddLoggedInUserAddressAsync([FromBody] AddressLoggedUserAddDTO model)
        {
            var result = await _userService.AddLoggedUserAddressAsync(model);
            return StatusCode((int)result.StatusCode, result);
        }

        /// <summary>
        /// Update logged user address
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Success when updating logged user address</returns>
        /// <response code="200">Returns success when updating logged user address</response>
        /// <response code="400">Returns error if the request fails</response>
        /// <response code="401">Not authorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal server error</response>   
        [HttpPut]
        [Route("logged-user-address")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResultResponse))]
        public async Task<ActionResult<ResultResponse>> UpdateLoggedInUserAddress([FromBody] UserLoggedUpdateDTO model)
        {
            var result = await _userService.UpdateLoggedUserAsync(model);
            return StatusCode((int)result.StatusCode, result);
        }

        /// <summary>
        /// Delete logged user address
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Success when deleting logged user address</returns>
        /// <response code="200">Returns success when deleting logged user address</response>
        /// <response code="400">Returns error if the request fails</response>
        /// <response code="401">Not authorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal server error</response>   
        [HttpDelete]
        [Route("logged-user-address/{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResultResponse))]
        public async Task<ActionResult<ResultResponse>> DeleteLoggedInUserAddress([FromRoute] AddressDeleteDTO model)
        {
            var result = await _userService.InactivateLoggedUserAddressAsync(model);
            return StatusCode((int)result.StatusCode, result);
        }

        /// <summary>
        /// Get logged in user addresses
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Success when get logged in user addresses</returns>
        /// <response code="200">Returns success when get logged in user addresses</response>
        /// <response code="401">Not authorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal server error</response>   
        [HttpGet]
        [Route("logged-user-address")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDataResponse<IEnumerable<AddressResultDTO>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResultResponse))]
        public async Task<ActionResult<ResultDataResponse<IEnumerable<AddressResultDTO>>>> GetLoggedInUserAddresss([FromRoute] AddressFilterDTO model)
        {
            var result = await _userService.GetLoggedUserAddressesAsync(model);
            return StatusCode((int)result.StatusCode, result);
        }

        /// <summary>
        /// Get logged in user address
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Success when get logged in user address</returns>
        /// <response code="200">Returns success when get logged in user address</response>
        /// <response code="401">Not authorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal server error</response>   
        [HttpGet]
        [Route("logged-user-address/{addressId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse<AddressResultDTO>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResultResponse))]
        public async Task<ActionResult<ResultResponse<AddressResultDTO>>> GetLoggedInUserAddress([FromRoute] AddressIdentifierDTO model)
        {
            var result = await _userService.GetLoggedUserAddressAsync(model.AddressId);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
