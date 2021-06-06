namespace PersonalBlog.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using PersonalBlog.Infrastructure.Enums;
    using SportsApp.Data.Models;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public IEnumerable<Team> Teams { get; set; } = new List<Team>();

        public IEnumerable<Player> Players { get; set; } = new List<Player>();

        public UserRole UserRole { get; set; } = UserRole.Normal;

    }
}
