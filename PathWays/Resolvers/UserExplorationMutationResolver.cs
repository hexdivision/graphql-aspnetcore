using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PathWays.Common.Utilities;
using PathWays.Data.Model;
using PathWays.GraphQL;
using PathWays.Services.UserExplorationService;
using PathWays.Types;

namespace PathWays.Resolvers
{
    public class UserExplorationMutationResolver : IMutationResolver
    {
        private readonly IMapper _mapper;
        private readonly IUserExplorationService _userExplorationService;
        private readonly IConfiguration _config;

        public UserExplorationMutationResolver(IUserExplorationService userExplorationService, IMapper mapper, IConfiguration config)
        {
            _userExplorationService = userExplorationService;
            _mapper = mapper;
            _config = config;
        }

        public void Resolve(GraphQLMutation graphQLMutation)
        {
            graphQLMutation.Field<UserExplorationType>(
                "createUserExploration",
                arguments:
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserExplorationInputType>> { Name = "userExploration" }),
                resolve: context =>
                {
                    try
                    {
                        var userExploration = context.GetArgument<UserExploration>("userExploration");

                        if (userExploration.ExplorationCompletionDate < DateTime.UtcNow)
                        {
                            return "Invalid Exploration Completion Date";
                        }

                        var result = _userExplorationService.CreateUserExploration(userExploration).Result;
                        return _mapper.Map<UserExploration>(result);
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                });

            graphQLMutation.Field<BooleanGraphType>(
                "deleteUserExploration",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userExplorationId", Description = "userExplorationId" }),
                resolve: context =>
                {
                    var userExplorationId = context.GetArgument<int>("userExplorationId");
                    var result = _userExplorationService.DeleteUserExploration(userExplorationId);
                    return result;
                });

            graphQLMutation.Field<UserExplorationType>(
                "updateUserExploration",
                arguments:
                new QueryArguments(
                    new QueryArgument<UserExplorationUpdateType> { Name = "userExploration" }),
                resolve: context =>
                {
                    try
                    {
                        var userExploration = context.GetArgument<UserExploration>("userExploration");
                        var id = userExploration.UserExplorationId;

                        if (id > 0)
                        {
                            var originalUserExploration = _userExplorationService.GetNoTrackingUserExploration(id).Result;
                            userExploration.ApplyPatchTo(ref originalUserExploration);
                            var result = _userExplorationService.UpdateUserExploration(originalUserExploration).Result;
                            return _mapper.Map<UserExploration>(result);
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

            graphQLMutation.Field<StringGraphType>(
                "accessCodeLogin",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "accessCode", Description = "Access Code" }),
                resolve: context =>
                {
                    try
                    {
                        var accessCode = context.GetArgument<string>("accessCode");

                        var userExploration = _userExplorationService.GetUserExploration(accessCode).Result;
                        if (userExploration != null)
                        {
                            if (userExploration.IsDeleted == true || userExploration.ExplorationCompletionDate < DateTime.Today)
                            {
                                return "Exploration is no longer accessible";
                            }
                            var result = BuildToken();
                            return result;
                        }
                        else
                        {
                            return "Unauthorized";
                        }
                    }
                    catch (Exception e)
                    {
                        return new UnauthorizedAccessException(e.Message);
                    }
                });
        }

        private string BuildToken()
        {
            var jwtKey = _config["Jwt:Key"];
            var jwtIssuer = _config["Jwt:Issuer"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "Role3"),
            };

            var token = new JwtSecurityToken(
                jwtIssuer,
                jwtIssuer,
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
