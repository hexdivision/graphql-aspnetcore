using AutoMapper;
using PathWays.GraphQL;
using PathWays.Services.TokenService;

namespace PathWays.Resolvers
{
    public class TokenQueryResolver : IQueryResolver
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public TokenQueryResolver(ITokenService tokenService, IMapper mapper)
        {
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public void Resolve(GraphQLQuery graphQLQuery)
        {
        }
    }
}
