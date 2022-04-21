using Ceci.Domain.Interfaces.Repository;
using Ceci.Infra.Data.Context;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Ceci.Infra.Data.Repository
{
    [ExcludeFromCodeCoverage]
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public IUserRepository User { get; }
        public IRoleRepository Role { get; }
        public IRefreshTokenRepository RefreshToken { get; }
        public IRegistrationTokenRepository RegistrationToken { get; }
        public IValidationCodeRepository ValidationCode { get; }

        public UnitOfWork(AppDbContext appDbContext,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IRefreshTokenRepository refreshTokenRepository,
            IRegistrationTokenRepository registrationToken,
            IValidationCodeRepository validationCode)
        {
            _appDbContext = appDbContext;
            User = userRepository;
            Role = roleRepository;
            RefreshToken = refreshTokenRepository;
            RegistrationToken = registrationToken;
            ValidationCode = validationCode;
        }

        public async Task CommitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _appDbContext.Dispose();
            }
        }
    }
}
