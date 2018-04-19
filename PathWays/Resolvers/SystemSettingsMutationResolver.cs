using System;
using AutoMapper;
using GraphQL.Types;
using PathWays.Data.Model;
using PathWays.GraphQL;
using PathWays.Services.SystemSettingsService;
using PathWays.Types;

namespace PathWays.Resolvers
{
    public class SystemSettingsMutationResolver : IMutationResolver
    {
        private readonly ISystemSettingsService _systemSettingsService;
        private readonly IMapper _mapper;

        public SystemSettingsMutationResolver(ISystemSettingsService systemSettingsService, IMapper mapper)
        {
            _systemSettingsService = systemSettingsService;
            _mapper = mapper;
        }

        public void Resolve(GraphQLMutation graphQLMutation)
        {
            graphQLMutation.Field<SystemSettingsType>(
                "createSetting",
                arguments:
                    new QueryArguments(
                        new QueryArgument<NonNullGraphType<SystemSettingsInputType>> { Name = "setting" }),
                resolve: context =>
                {
                    try
                    {
                        var setting = context.GetArgument<SystemSettings>("setting");
                        var result = _systemSettingsService.AddSettings(setting).Result;
                        return _mapper.Map<SystemSettings>(result);
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                });
        }
    }
}
