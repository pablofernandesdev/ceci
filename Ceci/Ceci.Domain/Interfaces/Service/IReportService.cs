using Ceci.Domain.DTO.Commons;
using Ceci.Domain.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceci.Domain.Interfaces.Service
{
    public interface IReportService
    {
        Task<ResultResponse<byte[]>> GenerateUsersReport(UserFilterDTO filter);
    }
}
