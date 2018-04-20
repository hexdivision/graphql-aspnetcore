using System;
using System.Collections.Generic;
using AutoMapper;
using GraphQL.Authorization;
using GraphQL.Types;
using PathWays.Data.Model;
using PathWays.GraphQL;
using PathWays.Services.SystemSettingsService;
using PathWays.Types;

namespace PathWays.Resolvers
{
    [GraphQLAuthorize(Policy = "AdminPolicy")]
    public class SystemSettingsQueryResolver : IQueryResolver
    {
        private readonly ISystemSettingsService _systemSettingsService;
        private readonly IMapper _mapper;

        public SystemSettingsQueryResolver(ISystemSettingsService systemSettingsService, IMapper mapper)
        {
            _systemSettingsService = systemSettingsService;
            _mapper = mapper;
        }

        public void Resolve(GraphQLQuery graphQLQuery)
        {
            graphQLQuery.Field<SystemSettingsType>(
                "setting",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the settings" }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    var setting = _systemSettingsService.GetSetting(id).Result;
                    var systemSettings = _mapper.Map<SystemSettings>(setting);
                    return systemSettings;
                });

            graphQLQuery.Field<ListGraphType<SystemSettingsType>>(
                "settings",
                resolve: context =>
                {
                    var settings = _systemSettingsService.GetListAsync().Result;
                    var systemSettings = _mapper.Map<List<SystemSettings>>(settings);
                    return systemSettings;
                });
        }
    }
}
