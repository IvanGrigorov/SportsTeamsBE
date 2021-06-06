namespace PersonalBlog.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PersonalBlog.Data.Models;
    using SportsApp.Data.Models;

    public class SportsAppDbContext : IdentityDbContext<User>
    {
        public SportsAppDbContext(DbContextOptions<SportsAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Player { get; set; }

        public DbSet<Team> Team { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Team>()
                .HasOne(t => t.User)
                .WithMany(u => u.Teams)
                .HasForeignKey(c => c.UserId);

            builder
               .Entity<Player>()
               .HasOne(p => p.User)
               .WithMany(u => u.Players)
               .HasForeignKey(c => c.UserId);


            builder
                .Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);


            base.OnModelCreating(builder);
        }
    }

    
}
