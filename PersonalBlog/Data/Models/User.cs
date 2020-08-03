namespace PersonalBlog.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using PersonalBlog.Infrastructure.Enums;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public IEnumerable<Project> Projects { get; set; } = new List<Project>();

        public IEnumerable<Article> Articles { get; set; } = new List<Article>();


        public UserRole UserRole { get; set; } = UserRole.Normal;

    }
}
