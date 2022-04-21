using Ceci.Domain.DTO.Commons;
using Ceci.Domain.DTO.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ceci.Domain.Interfaces.Service
{
    public interface IEmailService
    {
        Task<ResultResponse> SendEmailAsync(EmailRequestDTO emailRequest);
    }
}
