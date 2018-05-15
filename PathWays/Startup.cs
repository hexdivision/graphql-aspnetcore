using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GraphQL.Authorization.Extension;
using GraphQL.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PathWays.Data.Model;
using PathWays.Data.Repositories.Domain;
using PathWays.Data.Repositories.Pathway;
using PathWays.Data.Repositories.SystemSettings;
using PathWays.Data.Repositories.UnitOfWork;
using PathWays.Data.Repositories.User;
using PathWays.Data.Repositories.UserExploration;
using PathWays.Data.Repositories.UserExplorationToken;
using PathWays.Data.Repositories.UserPathway;
using PathWays.Data.Repositories.UserReport;
using PathWays.Data.Repositories.UserStep;
using PathWays.GraphQL;
using PathWays.Resolvers;
using PathWays.Services.PathwayService;
using PathWays.Services.ReportItem;
using PathWays.Services.SystemSettingsService;
using PathWays.Services.TokenService;
using PathWays.Services.UserExplorationService;
using PathWays.Services.UserPathwayService;
using PathWays.Services.UserReportService;
using PathWays.Services.UserStepService;
using PathWays.Types;
using PathWays.UserResolverService;

namespace PathWays
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;

            HostingEnvironment = hostingEnvironment;

            var builder = new ConfigurationBuilder()
                .SetBasePath(HostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{HostingEnvironment.EnvironmentName}.json", optional: false)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(
                options => options.AddPolicy(
                    "AllowCors",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowCredentials()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .WithExposedHeaders("Token", "Content-Type", "Authorization");
                    }));

            services.AddMvc();

            services.AddAutoMapper(typeof(Startup));

            services.AddGraphQl(schema =>
            {
                schema.SetQueryType<GraphQLQuery>();
                schema.SetMutationType<GraphQLMutation>();
            });

            services.AddGraphQLAuth();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            // TODO: Determine users roles
                            string clientId = context.Principal.FindFirstValue("appid");

                            var claims = new List<Claim>
                                {
                                    new Claim(ClaimTypes.Role, "User"),
                                };

                            var appIdentity = new ClaimsIdentity(claims);

                            context.Principal.AddIdentity(appIdentity);
                            return Task.CompletedTask;
                        }
                    };
                });

            // Postgres
            var connectionString = Configuration.GetConnectionString("DbConnection");
            services.AddEntityFrameworkNpgsql().AddDbContext<PathWaysContext>(c => c.UseNpgsql(connectionString), ServiceLifetime.Scoped);

            // MSSQL
            //// connectionString = Configuration.GetConnectionString("DbConnection");
            //// services.AddDbContext<PathWaysContext>(c => c.UseSqlServer(connectionString, b => b.MigrationsAssembly("PathWays.Data.Model")), ServiceLifetime.Scoped);

            services.AddScoped<GraphQLQuery>();
            services.AddScoped<GraphQLMutation>();
            services.AddScoped<TokenQueryResolver>();
            services.AddScoped<SystemSettingsQueryResolver>();
            services.AddScoped<SystemSettingsMutationResolver>();
            services.AddScoped<UserExplorationQueryResolver>();
            services.AddScoped<UserExplorationMutationResolver>();
            services.AddScoped<UserReportQueryResolver>();
            services.AddScoped<UserReportMutationResolver>();
            services.AddScoped<ReportItemQueryResolver>();
            services.AddScoped<ReportItemMutationResolver>();
            services.AddScoped<UserPathwayQueryResolver>();
            services.AddScoped<UserPathwayMutationResolver>();
            services.AddScoped<UserStepQueryResolver>();
            services.AddScoped<UserStepMutationResolver>();
            services.AddScoped<PathwayQueryResolver>();
            services.AddScoped<PathwayMutationResolver>();

            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<ISystemSettingsService, SystemSettingsService>();
            services.AddSingleton<IUserExplorationService, UserExplorationService>();
            services.AddSingleton<ITokenService, TokenService>();
            services.AddSingleton<IUserReportService, UserReportService>();
            services.AddSingleton<IReportItemService, ReportItemService>();
            services.AddSingleton<IUserPathwayService, UserPathwayService>();
            services.AddSingleton<IUserStepService, UserStepService>();
            services.AddSingleton<IPathwayService, PathwayService>();

            services.AddScoped<ISystemUserRepository, SystemUserRepository>();
            services.AddScoped<ISystemSettingsRepository, SystemSettingsRepository>();
            services.AddScoped<IUserExplorationRepository, UserExplorationRepository>();
            services.AddScoped<IUserExplorationTokenRepository, UserExplorationTokenRepository>();
            services.AddScoped<IUserReportRepository, UserReportRepository>();
            services.AddScoped<IReportItemRepository, ReportItemRepository>();
            services.AddScoped<IUserPathwayRepository, UserPathwayRepository>();
            services.AddScoped<IUserStepRepository, UserStepRepository>();
            services.AddScoped<PathwayRepository, PathwayRepository>();
            services.AddScoped<IDomainRepository, DomainRepository>();

            services.AddScoped<UserType>();
            services.AddScoped<UserInputType>();
            services.AddScoped<SystemSettingsType>();
            services.AddScoped<SystemSettingsInputType>();
            services.AddScoped<UserExplorationType>();
            services.AddScoped<UserExplorationInputType>();
            services.AddScoped<UserExplorationUpdateType>();
            services.AddScoped<UserExplorationTokenType>();

            services.AddScoped<UserReportType>();
            services.AddScoped<UserReportInputType>();
            services.AddScoped<UserReportUpdateType>();

            services.AddScoped<ReportItemType>();
            services.AddScoped<ReportItemInputType>();
            services.AddScoped<ReportItemUpdateType>();

            services.AddScoped<UserPathwayType>();
            services.AddScoped<UserPathwayInputType>();
            services.AddScoped<UserPathwayUpdateType>();

            services.AddScoped<UserStepType>();
            services.AddScoped<UserStepInputType>();
            ////services.AddScoped<UserStepUpdateType>();

            services.AddScoped<PathwayType>();
            services.AddScoped<PathwayInputType>();

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

            app.UseAuthentication();

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
                var rules = app.ApplicationServices.GetServices<IValidationRule>();

                foreach (IValidationRule rule in rules)
                {
                    options.ValidationRules.Add(rule);
                }

                options.BuildUserContext = ctx =>
                {
                    var userContext = new GraphQLUserContext
                    {
                        User = ctx.User
                    };

                    return Task.FromResult(userContext);
                };

                options.FormatOutput = false;
            });

            app.UseMvc();
            app.UseStaticFiles();

            app.UseCors("AllowCors");
        }
    }
}
