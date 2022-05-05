using Ceci.Domain.DTO.Address;
using Ceci.Domain.DTO.Commons;
using Ceci.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ceci.WebApplication.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/address")]
    [ApiController]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressService"></param>
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        /// <summary>
        /// Get address by zip code
        /// </summary>
        /// <returns>Success when get the address</returns>
        /// <response code="200">Returns success when get address</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>   
        [HttpGet]
        [Route("zip-code/{zipCode}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultResponse<AddressResultDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ResultResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResultResponse))]
        public async Task<ActionResult<ResultResponse<AddressResultDTO>>> GetByZipCode([FromRoute] AddressZipCodeDTO model)
        {
            var result = await _addressService.GetAddressByZipCodeAsync(model);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
