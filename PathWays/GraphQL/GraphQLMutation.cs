using System;
using System.Linq;
using AutoMapper;
using GraphQL.Types;

namespace PathWays.GraphQL
{
    public class GraphQLMutation : ObjectGraphType
    {
        public GraphQLMutation(IServiceProvider serviceProvider)
        {
            var type = typeof(IMutationResolver);
            var resolversTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach (var resolverType in resolversTypes)
            {
                if (resolverType.IsClass)
                {
                    var resolverTypeInterface = resolverType.GetInterfaces().FirstOrDefault();
                    if (resolverTypeInterface != null)
                    {
                        var resolver = serviceProvider.GetService(resolverTypeInterface) as IMutationResolver;
                        resolver.Resolve(this);
                    }
                }
            }
        }
    }
}
