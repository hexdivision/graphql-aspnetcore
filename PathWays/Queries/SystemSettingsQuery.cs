using System.Collections.Generic;
using AutoMapper;
using GraphQL.Types;
using PathWays.Data.Model;
using PathWays.Services.SystemSettingsService;
using PathWays.Types;

namespace PathWays.Queries
{
    public class SystemSettingsQuery : ObjectGraphType
    {
        public SystemSettingsQuery(ISystemSettingsService systemSettingsService, IMapper mapper)
        {
            Name = "Query";

            Field<SystemSettingsType>(
                "setting",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the settings" }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    var setting = systemSettingsService.GetSetting(id);
                    var systemSettings = mapper.Map<SystemSettings>(setting);
                    return systemSettings;
                });

            Field<ListGraphType<SystemSettingsType>>(
                "settings",
                resolve: context =>
                {
                    var settings = systemSettingsService.GetListAsync().Result;
                    var systemSettings = mapper.Map<List<SystemSettings>>(settings);
                    return systemSettings;
                });
        }
    }
}
