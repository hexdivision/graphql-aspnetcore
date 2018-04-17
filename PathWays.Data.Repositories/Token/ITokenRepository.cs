using System.Threading.Tasks;
using PathWays.Data.Model;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.Token
{
    public interface ITokenRepository : IRepository<UserToken>
    {
        UserToken GetToken(string authToken);

        Task<UserToken> GetTokenAsync(string authToken);
    }
}
