using Ceci.Domain.DTO.Commons;
using Ceci.Domain.DTO.Role;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ceci.Domain.Interfaces.Service
{
    public interface IRoleService
    {
        Task<ResultDataResponse<IEnumerable<RoleResultDTO>>> GetAsync();
        Task<ResultResponse> AddAsync(RoleAddDTO obj);
        Task<ResultResponse> DeleteAsync(int id);
        Task<ResultResponse> UpdateAsync(RoleUpdateDTO obj);
        Task<ResultResponse<RoleResultDTO>> GetByIdAsync(int id);
    }
}
