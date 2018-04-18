using System;
using AutoMapper;
using GraphQL.Types;
using PathWays.Data.Model;
using PathWays.Services.SystemSettingsService;
using PathWays.Types;

namespace PathWays.Mutations
{
    public class SystemSettingsMutation : ObjectGraphType
    {
        public SystemSettingsMutation(ISystemSettingsService systemSettingsService, IMapper mapper)
        {
            Name = "Mutation";

            Field<SystemSettingsType>(
                "createSetting",
                arguments:
                    new QueryArguments(
                        new QueryArgument<NonNullGraphType<SystemSettingsInputType>> { Name = "setting" }),
                resolve: context =>
                {
                    try
                    {
                        var setting = context.GetArgument<SystemSettings>("setting");
                        var result = systemSettingsService.AddSettings(setting).Result;
                        return mapper.Map<SystemSettings>(result);
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                });
        }
    }
}
