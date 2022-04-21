using Ceci.Domain.DTO.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceci.Domain.Interfaces.Service.External
{
    public interface IFirebaseService
    {
        Task<ResultResponse> SendNotificationAsync(string token, string title, string body);
    }
}
