using AutoMapper;
using GraphQl.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PathWays.Data.Model;
using PathWays.Data.Repositories.SystemSettings;
using PathWays.Data.Repositories.Token;
using PathWays.Data.Repositories.UnitOfWork;
using PathWays.Data.Repositories.User;
using PathWays.Models;
using PathWays.UserResolverService;

namespace PathWays
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddAutoMapper(typeof(Startup));

            services.AddGraphQl(schema =>
            {
                schema.SetQueryType<PathWaysQuery>();
                schema.SetMutationType<PathWaysMutation>();
            });

            services.AddDbContext<PathWaysContext>(c => c.UseSqlServer(Configuration.GetConnectionString("DbConnection"), b => b.MigrationsAssembly("PathWays.Data.Model")), ServiceLifetime.Scoped);

            services.AddScoped<PathWaysQuery>();
            services.AddScoped<PathWaysMutation>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ISystemUserRepository, SystemUserRepository>();
            services.AddScoped<ISystemSettingsRepository, SystemSettingsRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<SystemSettingsType>();
            services.AddScoped<SystemSettingsInputType>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IUserResolver, UserResolver>();

            var sp = services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<PathWaysContext>();
                context.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseGraphiql("/graphiql", options =>
                {
                    options.GraphQlEndpoint = "/graphql";
                });
            }

            app.UseGraphQl("/graphql", options =>
            {
                options.FormatOutput = false;
            });

            app.UseMvc();
            app.UseStaticFiles();
        }
    }
}
