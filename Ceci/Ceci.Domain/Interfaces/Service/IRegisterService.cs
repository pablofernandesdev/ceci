using Ceci.Domain.DTO.Address;
using Ceci.Domain.DTO.Commons;
using Ceci.Domain.DTO.Register;
using Ceci.Domain.DTO.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ceci.Domain.Interfaces.Service
{
    public interface IRegisterService
    {
        Task<ResultResponse<UserResultDTO>> GetLoggedInUserAsync();
        Task<ResultResponse> SelfRegistrationAsync(UserSelfRegistrationDTO obj);
        Task<ResultResponse> UpdateLoggedUserAsync(UserLoggedUpdateDTO obj);
        Task<ResultResponse> RedefinePasswordAsync(UserRedefinePasswordDTO obj);
        Task<ResultResponse> AddLoggedUserAddressAsync(AddressLoggedUserAddDTO obj);
        Task<ResultResponse> UpdateLoggedUserAddressAsync(AddressLoggedUserUpdateDTO obj);
        Task<ResultResponse> InactivateLoggedUserAddressAsync(AddressDeleteDTO obj);
        Task<ResultDataResponse<IEnumerable<AddressResultDTO>>> GetLoggedUserAddressesAsync(AddressFilterDTO filter);
        Task<ResultResponse<AddressResultDTO>> GetLoggedUserAddressAsync(int addressId);
    }
}
