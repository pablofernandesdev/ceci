using Ceci.Domain.DTO.Address;
using Ceci.Domain.DTO.Commons;
using System.Threading.Tasks;

namespace Ceci.Domain.Interfaces.Service
{
    public interface IAddressService
    {
        Task<ResultResponse<AddressResultDTO>> GetAddressByZipCodeAsync(AddressZipCodeDTO obj);
    }
}
