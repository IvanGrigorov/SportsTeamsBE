namespace PersonalBlog.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using PersonalBlog.Data;
    using PersonalBlog.Data.Models;
    using PersonalBlog.Features.Articles;
    using PersonalBlog.Features.Discovery;
    using PersonalBlog.Features.Galleries;
    using PersonalBlog.Features.Identity;
    using PersonalBlog.Features.Projects;
    using PersonalBlog.Features.ProjectTechnologies;
    using PersonalBlog.Features.Search;
    using PersonalBlog.Features.Technologies;
    using PersonalBlog.Infrastructure.Filters;

    public static class ServicesConfigurationExtensions
    {
        public static IServiceCollection AddDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PersonalBlogDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            return services;
        } 
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<PersonalBlogDbContext>();

            return services;
        }

        public static IServiceCollection AddJWTAuthentication(this IServiceCollection services, byte[] key)
        {
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
               .AddJwtBearer(x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(key),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               });
           return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IIdentityService, IdentityService>()
                    .AddTransient<IProjectService, ProjectService>()
                    .AddTransient<ITechologyService, TechnologyService>()
                    .AddTransient<IProjectTecnologyService, ProjectTecnologyService>()
                    .AddTransient<IGalleryService, GalleryService>()
                    .AddTransient<ISearchService, SearchService>()
                    .AddTransient<IArticleService, ArticleService>()
                    .AddTransient<IDiscoveryService, DiscoveryService>();

            return services;
        }

        public static IServiceCollection AddControllerServices(this IServiceCollection services)
        {
            services.AddControllers(options => options.Filters.Add<ObjectResultFilter>());
            return services;
        }
    }
}
