﻿using Ceci.Domain.DTO.Address;
using Ceci.Domain.DTO.Commons;
using Ceci.Domain.DTO.ViaCep;
using Ceci.Domain.Interfaces.Service.External;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ceci.Service.Services.External
{
    public class ViaCepService : IViaCepService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResultResponse<ViaCepAddressResponseDTO>> GetAddressByZipCodeAsync(string zipCode)
        {
            var response = new ResultResponse<ViaCepAddressResponseDTO>();

            var requestApi = await _httpClient.GetAsync($"/ws/{zipCode}/json/");

            response.StatusCode = requestApi.StatusCode;

            var dataRequest = await requestApi.Content.ReadAsStringAsync();

            if (!requestApi.IsSuccessStatusCode)
            {
                response.Message = dataRequest;
                return response;
            }

            response.Data = JsonConvert.DeserializeObject<ViaCepAddressResponseDTO>(dataRequest);

            return response;
        }
    }
}
