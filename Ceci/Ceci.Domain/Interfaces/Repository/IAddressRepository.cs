using Ceci.Domain.DTO.Address;
using Ceci.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ceci.Domain.Interfaces.Repository
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<IEnumerable<Address>> GetLoggedUserAddressesAsync(int userId, AddressFilterDTO filter);
        Task<int> GetTotalLoggedUserAddressesAsync(int userId, AddressFilterDTO filter);
        Task<IEnumerable<Address>> GetByFilterAsync(AddressFilterDTO filter);
        Task<int> GetTotalByFilterAsync(AddressFilterDTO filter);
    }
}
