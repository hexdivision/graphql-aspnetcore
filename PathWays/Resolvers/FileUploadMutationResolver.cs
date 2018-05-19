using System;
using AutoMapper;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using PathWays.Data.Model;
using PathWays.GraphQL;
using PathWays.Helpers;
using PathWays.Types;

namespace PathWays.Resolvers
{
    public class FileUploadMutationResolver : IMutationResolver
    {
        private readonly IMapper _mapper;

        public FileUploadMutationResolver(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Resolve(GraphQLMutation graphQLMutation)
        {
            graphQLMutation.Field<SystemSettingsType>(
                "createFileUpload",
                arguments:
                    new QueryArguments(
                    new QueryArgument<NonNullGraphType<SystemSettingsInputType>> { Name = "file" }),
                resolve: context =>
                {
                    try
                    {
                        var setting = context.GetArgument<SystemSettings>("file");

                        var tempFileFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                        var fileType = new object();
                        var files = FileStreamingHelper.ParseRequestForm((HttpContext)context.RootValue, tempFileFolder, fileType).Result;

                        return null;
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                });
        }
    }
}
