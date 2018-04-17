using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PathWays.Data.Model;
using PathWays.Data.Repositories.Base;

namespace PathWays.Data.Repositories.Token
{
    public class TokenRepository : PathWaysRepository<UserToken>, ITokenRepository
    {
        public TokenRepository(PathWaysContext context)
            : base(context)
        {
        }

        public UserToken GetToken(string authToken)
        {
            var token = Context.UserTokens.SingleOrDefault(t => t.AuthToken == authToken && t.ExpiresOn > DateTime.Now);
            return token;
        }

        public async Task<UserToken> GetTokenAsync(string authToken)
        {
            try
            {
                var token = await Context.UserTokens.SingleOrDefaultAsync(t => t.AuthToken == authToken && t.ExpiresOn > DateTime.Now);
                return token;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
