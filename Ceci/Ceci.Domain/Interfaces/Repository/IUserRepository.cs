using Ceci.Domain.DTO.User;
using Ceci.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ceci.Domain.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetByFilterAsync(UserFilterDTO filter);
        Task<int> GetTotalByFilterAsync(UserFilterDTO filter);
    }
}
