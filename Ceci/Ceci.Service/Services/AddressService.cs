using AutoMapper;
using Ceci.Domain.DTO.Address;
using Ceci.Domain.DTO.Commons;
using Ceci.Domain.Interfaces.Service;
using Ceci.Domain.Interfaces.Service.External;
using System;
using System.Threading.Tasks;

namespace Ceci.Service.Services
{
    public class AddressService : IAddressService
    {
        private readonly IViaCepService _viaCepService;
        private readonly IMapper _mapper;

        public AddressService (IViaCepService viaCepService, IMapper mapper)
        {
            _viaCepService = viaCepService;
            _mapper = mapper;
        }

        public async Task<ResultResponse<AddressResultDTO>> GetAddressByZipCodeAsync(AddressZipCodeDTO obj)
        {
            var response = new ResultResponse<AddressResultDTO>();

            try
            {
                var addressRequest = await _viaCepService.GetAddressByZipCodeAsync(obj.ZipCode);

                response.StatusCode = addressRequest.StatusCode;

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    response.Message = "Unable to get address. Check that the zip code was entered correctly.";
                    return response;
                }

                response.Data = _mapper.Map<AddressResultDTO>(addressRequest.Data);
            }
            catch (Exception ex)
            {
                response.Message = "Could not get address.";
                response.Exception = ex;
            }

            return response;
        }
    }
}
