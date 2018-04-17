using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GraphQL.Types;
using PathWays.Data.Model;
using PathWays.Data.Repositories.SystemSettings;
using PathWays.Data.Repositories.User;

namespace PathWays.Models
{
    public class PathWaysQuery : ObjectGraphType
    {
        public PathWaysQuery(ISystemSettingsRepository systemSettingsRepository, ISystemUserRepository systemUserRepository, IMapper mapper)
        {
            Name = "Query";

            Field<SystemSettingsType>(
                "setting",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the settings" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var settings = systemSettingsRepository.GetById(id);
                    var systemSettings = mapper.Map<SystemSettings>(settings);
                    return systemSettings;
                });

            Field<ListGraphType<SystemSettingsType>>(
                "settings",
                resolve: context =>
                {
                    var settings = systemSettingsRepository.GetAllAsync().Result;
                    var systemSettings = mapper.Map<List<SystemSettings>>(settings);
                    return systemSettings;
                });
        }
    }
}
