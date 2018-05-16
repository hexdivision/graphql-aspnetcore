using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GraphQL.Types;
using PathWays.Common.Utilities;
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

                        var isDomainExists = _pathwayService.IsDomainExists(pathway.DomainId).Result;

                        if (!isDomainExists)
                        {
                            return "Domain with specified Id not exists";
                        }

                        var result = _pathwayService.CreateAsync(pathway).Result;
                        return _mapper.Map<Pathway>(result);
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                });

            graphQLMutation.Field<PathwayType>(
                "updatePathway",
                arguments:
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<PathwayUpdateType>> { Name = "pathway" }),
                resolve: context =>
                {
                    try
                    {
                        var pathway = context.GetArgument<Pathway>("pathway");
                        var id = pathway.PathwayId;

                        if (id > 0)
                        {
                            var originalPathway = _pathwayService.GetNoTrackingPathway(id).Result;
                            pathway.ApplyPatchTo(ref originalPathway);
                            var result = _pathwayService.UpdatePathway(originalPathway).Result;
                            return _mapper.Map<Pathway>(result);
                        }
                        else
                        {
                            return "Model is Invalid";
                        }
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                });

            graphQLMutation.Field<BooleanGraphType>(
                "deletePathway",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "pathwayId", Description = "pathwayId" }),
                resolve: context =>
                {
                    var pathwayId = context.GetArgument<int>("pathwayId");
                    var result = _pathwayService.DeletePathway(pathwayId);
                    return result;
                });
        }
    }
}
