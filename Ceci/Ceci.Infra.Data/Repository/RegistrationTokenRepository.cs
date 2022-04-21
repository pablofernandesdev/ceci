using Ceci.Domain.Entities;
using Ceci.Domain.Interfaces.Repository;
using Ceci.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceci.Infra.Data.Repository
{
    [ExcludeFromCodeCoverage]
    public class RegistrationTokenRepository : BaseRepository<RegistrationToken>, IRegistrationTokenRepository
    {
        public RegistrationTokenRepository(AppDbContext appDbcontext) : base(appDbcontext)
        {
        }
    }
}
