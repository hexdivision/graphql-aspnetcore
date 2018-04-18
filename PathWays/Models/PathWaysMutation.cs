using System.Collections.Generic;
using AutoMapper;
using GraphQL.Types;
using PathWays.Data.Model;
using PathWays.Data.Repositories.SystemSettings;

namespace PathWays.Models
{
    public class PathWaysMutation : ObjectGraphType
    {
        public PathWaysMutation(ISystemSettingsRepository systemSettingsRepository, IMapper mapper)
        {
            Name = "Mutation";

            Field<SystemSettingsType>(
                "createSetting",
                arguments:
                    new QueryArguments(
                        new QueryArgument<NonNullGraphType<SystemSettingsInputType>> { Name = "setting" }),
                resolve: context =>
                {
                    var setting = context.GetArgument<SystemSettings>("setting");
                    var result = systemSettingsRepository.InsertAsync(setting);
                    var systemSettings = mapper.Map<List<SystemSettings>>(result);
                    return systemSettings;
                });
        }
    }
}
