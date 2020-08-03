namespace PersonalBlog.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using PersonalBlog.Data;

    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();
            var dbContext = services.ServiceProvider.GetService<PersonalBlogDbContext>();

            dbContext.Database.Migrate();
        }

        public static IApplicationBuilder AddSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Blog Api v1");
                    c.RoutePrefix = string.Empty;
                });
            return app;

        }
    }
}
