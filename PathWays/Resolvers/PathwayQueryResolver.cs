using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GraphQL.Types;
using PathWays.Data.Model;
using PathWays.GraphQL;
using PathWays.Services.PathwayService;
using PathWays.Types;

namespace PathWays.Resolvers
{
    public class PathwayQueryResolver : IQueryResolver
    {
        private readonly IPathwayService _pathwayService;
        private readonly IMapper _mapper;

        public PathwayQueryResolver(IPathwayService pathwayService, IMapper mapper)
        {
            _pathwayService = pathwayService;
            _mapper = mapper;
        }

        public void Resolve(GraphQLQuery graphQLQuery)
        {
            graphQLQuery.Field<PathwayType>(
                "pathway",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the pathway" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var pathway = _pathwayService.GetPathway(id).Result;
                    var pathwayType = _mapper.Map<Pathway>(pathway);
                    return pathwayType;
                });
        }
    }
}
