using System;
using System.Collections.Generic;
using AutoMapper;
using GraphQL.Types;
using PathWays.Data.Model;
using PathWays.Data.Repositories.SystemSettings;
using PathWays.Data.Repositories.UnitOfWork;
using PathWays.Data.Repositories.User;

namespace PathWays.Models
{
    public class PathWaysMutation : ObjectGraphType
    {
        public PathWaysMutation(ISystemSettingsRepository systemSettingsRepository, ISystemUserRepository systemUserRepository, IMapper mapper, IUnitOfWork unitOfWork)
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
                        var result = unitOfWork.SystemSettingsRepository.InsertAsync(setting).Result;
                        unitOfWork.Complete();
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
