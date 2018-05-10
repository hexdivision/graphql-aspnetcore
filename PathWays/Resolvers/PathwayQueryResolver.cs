using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PathWays.GraphQL;
using PathWays.Services.PathwayService;

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
        }
    }
}
