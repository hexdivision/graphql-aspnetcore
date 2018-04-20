using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using GraphQL.Authorization;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PathWays.Data.Model;
using PathWays.GraphQL;
using PathWays.Services.TokenService;
using PathWays.Types;

namespace PathWays.Resolvers
{
    public class TokenMutationResolver : IMutationResolver
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public TokenMutationResolver(ITokenService tokenService, IMapper mapper, IConfiguration config)
        {
            _tokenService = tokenService;
            _mapper = mapper;
            _config = config;
        }

        public void Resolve(GraphQLMutation graphQLMutation)
        {
            graphQLMutation.Field<StringGraphType>(
                "createToken",
                arguments:
                    new QueryArguments(
                        new QueryArgument<NonNullGraphType<UserInputType>> { Name = "credentials" }),
                resolve: context =>
                {
                    try
                    {
                        var credentials = context.GetArgument<UserModel>("credentials");
                        var isAutorized = _tokenService.Login(credentials.User, credentials.Password);

                        if (isAutorized == false)
                        {
                            return new UnauthorizedAccessException();
                        }

                        var result = BuildToken(credentials);
                        return result;
                    }
                    catch (Exception e)
                    {
                        return new UnauthorizedAccessException(e.Message);
                    }
                });
        }

        private string BuildToken(UserModel user)
        {
            var jwtKey = _config["Jwt:Key"];
            var jwtIssuer = _config["Jwt:Issuer"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwtIssuer,
                jwtIssuer,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
