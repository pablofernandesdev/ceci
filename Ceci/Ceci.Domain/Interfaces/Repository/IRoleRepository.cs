using Ceci.Domain.Entities;
using System.Threading.Tasks;

namespace Ceci.Domain.Interfaces.Repository
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<Role> GetBasicProfile();
    }
}
