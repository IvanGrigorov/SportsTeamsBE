namespace PersonalBlog.Infrastructure.Extensions
{
    using PersonalBlog.Infrastructure.Enums;
    using System;
    using System.Linq;
    using System.Security.Claims;

    public static class IdentityExtensions
    {

        public static string GetId(this ClaimsPrincipal user)
        {
            return user.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?
                .Value;
        }

        public static UserRole GetUserRole(this ClaimsPrincipal user)
        {
            var roleAsString = user.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Role)?
                .Value;

            return (UserRole)Enum.Parse(typeof(UserRole), roleAsString);
        }
    }
}
