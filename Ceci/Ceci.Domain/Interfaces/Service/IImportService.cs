using Ceci.Domain.DTO.Commons;
using Ceci.Domain.DTO.Import;
using System.Threading.Tasks;

namespace Ceci.Domain.Interfaces.Service
{
    public interface IImportService
    {
        Task<ResultResponse> ImportUsersAsync(FileUploadDTO model);
    }
}
