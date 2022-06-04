using Ceci.Domain.DTO.User;
using Ceci.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ceci.Domain.Interfaces.Service
{
    public interface ITokenService
    {
        public string GenerateToken(UserResultDTO model);
    }
}
