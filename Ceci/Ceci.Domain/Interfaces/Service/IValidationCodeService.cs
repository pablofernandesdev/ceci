using Ceci.Domain.DTO.Commons;
using Ceci.Domain.DTO.ValidationCode;
using System.Threading.Tasks;

namespace Ceci.Domain.Interfaces.Service
{
    public interface IValidationCodeService
    {
        Task<ResultResponse> SendAsync();
        Task<ResultResponse> ValidateCodeAsync(ValidationCodeValidateDTO obj);
    }
}
