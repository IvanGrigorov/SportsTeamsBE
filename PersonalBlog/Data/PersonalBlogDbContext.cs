namespace PersonalBlog.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PersonalBlog.Data.Models;

    public class PersonalBlogDbContext : IdentityDbContext<User>
    {
        public PersonalBlogDbContext(DbContextOptions<PersonalBlogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Project { get; set; }

        public DbSet<Article> Article { get; set; }

        public DbSet<Technology> Technology { get; set; }

        public DbSet<ProjectTechnology> ProjectTechnology { get; set; }

        public DbSet<Gallery> Gallery { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Project>()
                .HasOne(p => p.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(c => c.UserId);


            builder.Entity<ProjectTechnology>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.ProjectTechnologies)
                .HasForeignKey(pt => pt.ProjectId);

            builder.Entity<ProjectTechnology>()
                .HasOne(pt => pt.Technology)
                .WithMany(p => p.ProjectTechnologies)
                .HasForeignKey(pt => pt.TechnologyId);

            builder.Entity<Gallery>()
                .HasOne(g => g.Project)
                .WithMany(p => p.Gallery)
                .HasForeignKey(k => k.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Gallery>()
                .HasOne(g => g.Article)
                .WithMany(a => a.Gallery)
                .HasForeignKey(k => k.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);
                

            builder.Entity<Article>()
                .HasOne(a => a.User)
                .WithMany(u => u.Articles)
                .HasForeignKey(k => k.UserId)
                .OnDelete(DeleteBehavior.NoAction);




            base.OnModelCreating(builder);
        }
    }

    
}
