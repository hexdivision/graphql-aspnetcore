using Microsoft.AspNetCore.Http;

namespace PathWays.UserResolverService
{
    public class UserResolver : IUserResolver
    {
        private readonly IHttpContextAccessor accessor;

        public UserResolver(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        public int GetUserId()
        {
            var username = accessor?.HttpContext?.User?.Identity?.Name;
            return int.Parse(username ?? "0");
        }
    }
}
