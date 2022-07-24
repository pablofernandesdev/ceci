using Ceci.Domain.Entities;
using Ceci.Domain.Interfaces.Repository;
using Ceci.Infra.Data.Context;
using System.Diagnostics.CodeAnalysis;

namespace Ceci.Infra.Data.Repository
{
    [ExcludeFromCodeCoverage]
    public class RefreshTokenRepository : BaseRepository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(AppDbContext appDbcontext) : base(appDbcontext)
        {
        }
    }
}
