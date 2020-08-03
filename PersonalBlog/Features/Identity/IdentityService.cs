namespace PersonalBlog.Features.Identity
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using PersonalBlog.Data;
    using PersonalBlog.Features.Bases;
    using PersonalBlog.Features.Identity.Models;
    using PersonalBlog.Infrastructure.Enums;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class IdentityService : BaseApiService, IIdentityService
    {

        public IdentityService(PersonalBlogDbContext personalBlogDbContext) : base(personalBlogDbContext)
        {

        }

        public string GenerateJWTToken(string userId, string userName, UserRole userRole, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Role, userRole.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }

        public async Task<ActionResult<UserResponseModel>> GetUserInfo(string userId)
        {
            return await this.personalBlogDbContext
                .Users
                .Where(u => u.Id == userId)
                .Select(u => new UserResponseModel()
                {
                    UserName = u.UserName,
                    IsAdmin = (u.UserRole == UserRole.Admin) ? true : false
                })
                .FirstOrDefaultAsync();

        }
    }
}
