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
    public class PathwayMutationResolver : IMutationResolver
    {
        private readonly IMapper _mapper;
        private readonly IPathwayService _pathwayService;

        public PathwayMutationResolver(IMapper mapper, IPathwayService pathwayService)
        {
            _mapper = mapper;
            _pathwayService = pathwayService;
        }

        public void Resolve(GraphQLMutation graphQLMutation)
        {
            graphQLMutation.Field<PathwayType>(
                "createPathway",
                arguments:
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<PathwayInputType>> { Name = "pathway" }),
                resolve: context =>
                {
                    try
                    {
                        var pathway = context.GetArgument<Pathway>("pathway");

                        var result = _pathwayService.CreateAsync(pathway).Result;
                        return _mapper.Map<Pathway>(result);
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                });
        }
    }
}
