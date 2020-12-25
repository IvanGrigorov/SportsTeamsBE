namespace PersonalBlog
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System.Text;
    using PersonalBlog.Infrastructure.Extensions;

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

            var appSettingsConfig = Configuration.GetSection("ApplicationSettings");
            var appSettings = appSettingsConfig.Get<ApplicationSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services
                .AddDB(this.Configuration)
                .Configure<ApplicationSettings>(appSettingsConfig)
                .AddIdentity()
                .AddJWTAuthentication(key)
                .AddApplicationServices()
                .AddSwaggerGen()
                .AddControllerServices();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app
                .UseSwagger()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .AddSwaggerUI()
                .UseStaticFiles()
                .UseCors(x => x
                    .WithOrigins("https://ivanit.eu")
                    .AllowAnyMethod()
                    .AllowAnyHeader())
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                })
                .ApplyMigrations();
        }
    }
}
