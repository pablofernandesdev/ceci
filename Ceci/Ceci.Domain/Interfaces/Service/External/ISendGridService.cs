using Ceci.Domain.DTO.Commons;
using System.Threading.Tasks;

namespace Ceci.Domain.Interfaces.Service.External
{
    public interface ISendGridService
    {
        Task<ResultResponse> SendEmailAsync(string email, string subject, string message);
    }
}
