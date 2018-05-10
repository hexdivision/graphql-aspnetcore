using System.Collections.Generic;
using AutoMapper;
using GraphQL.Types;
using PathWays.Data.Model;
using PathWays.GraphQL;
using PathWays.Services.UserPathwayService;
using PathWays.Types;

namespace PathWays.Resolvers
{
    public class UserPathwayQueryResolver : IQueryResolver
    {
        private readonly IMapper _mapper;
        private readonly IUserPathwayService _userPathwayService;

        public UserPathwayQueryResolver(IMapper mapper, IUserPathwayService userPathwayService)
        {
            _mapper = mapper;
            _userPathwayService = userPathwayService;
        }

        public void Resolve(GraphQLQuery graphQLQuery)
        {
            graphQLQuery.Field<UserPathwayType>(
                "userPathway",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the user pathway" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var userPathway = _userPathwayService.GetByIdAsync(id).Result;
                    var userPathwayType = _mapper.Map<UserPathway>(userPathway);
                    return userPathwayType;
                });

            graphQLQuery.Field<ListGraphType<UserPathwayType>>(
                "userPathways",
                resolve: context =>
                {
                    var userPathways = _userPathwayService.GetAllAsync().Result;
                    var userPathwaysType = _mapper.Map<List<UserPathway>>(userPathways);
                    return userPathwaysType;
                });
        }
    }
}
