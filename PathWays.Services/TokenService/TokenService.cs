using System.Collections.Generic;
using System.Threading.Tasks;
using PathWays.Data.Model;
using PathWays.Data.Repositories.UnitOfWork;

namespace PathWays.Services.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TokenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Login(string user, string password)
        {
            // TODO: Check if user credentials are correct
            return true;
        }
    }
}
