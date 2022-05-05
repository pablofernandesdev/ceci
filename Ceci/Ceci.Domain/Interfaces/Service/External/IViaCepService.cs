using Ceci.Domain.DTO.Address;
using Ceci.Domain.DTO.Commons;
using Ceci.Domain.DTO.ViaCep;
using System.Threading.Tasks;

namespace Ceci.Domain.Interfaces.Service.External
{
    public interface IViaCepService
    {
        Task<ResultResponse<ViaCepAddressResponseDTO>> GetAddressByZipCodeAsync(string zipCode);
    }
}
