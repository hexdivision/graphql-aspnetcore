using PathWays.Data.Repositories.UnitOfWork;
using PathWays.Services.UserExplorationService;

namespace PathWays.Services.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserExplorationService _userExporationService;

        public TokenService(IUnitOfWork unitOfWork, IUserExplorationService userExporationService)
        {
            _unitOfWork = unitOfWork;
            _userExporationService = userExporationService;
        }

        public bool Login(string user, string password)
        {
            // TODO: Check if user credentials are correct
            return true;
        }
    }
}
