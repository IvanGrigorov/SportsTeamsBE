using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Features.Identity.Models;
using PersonalBlog.Infrastructure.Enums;
using System.Threading.Tasks;

namespace PersonalBlog.Features.Identity
{
    public interface IIdentityService
    {
        public string GenerateJWTToken(string userId, string userName, UserRole userRole, string secret);

        public Task<ActionResult<UserResponseModel>> GetUserInfo(string userId);

    }
}
