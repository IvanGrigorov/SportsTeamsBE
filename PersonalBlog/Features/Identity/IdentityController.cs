namespace PersonalBlog.Features.Identity
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using PersonalBlog.Data.Models;
    using PersonalBlog.Features.Bases;
    using PersonalBlog.Features.Identity.Models;
    using PersonalBlog.Infrastructure.Enums;
    using PersonalBlog.Infrastructure.Extensions;
    using System;
    using System.Threading.Tasks;
    public class IdentityController : BaseAppController
    {

        private readonly UserManager<User> userManager;
        private readonly ApplicationSettings appSettings;
        private readonly IIdentityService identityService;


        public IdentityController(UserManager<User> userManager, IOptions<ApplicationSettings> appSettings, IIdentityService identityService)
        {
            this.userManager = userManager;
            this.appSettings = appSettings.Value;
            this.identityService = identityService;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<IActionResult> Register(RegisterUserModel userRegisterModel)
        {
            var userToCreate = new User
            {
                Email = userRegisterModel.Email,
                UserName = userRegisterModel.UserName,
                UserRole = UserRole.Normal
            };

            var user = await this.userManager.CreateAsync(userToCreate, userRegisterModel.Password);
            
            if (user.Succeeded)
            {
                return Ok();
            }

            return BadRequest(user.Errors);

        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<String>> Login(LoginUserModel userLoginModel)
        {
            var user = await this.userManager.FindByNameAsync(userLoginModel.UserName);

            if (user == null)
            {
                return Unauthorized("Wrong Username !");
            }

            var isPasswordValid = await this.userManager.CheckPasswordAsync(user, userLoginModel.Password);

            if (!isPasswordValid)
            {
                return Unauthorized("Wrong Password !");
            }


            return this.identityService.GenerateJWTToken(user.Id, user.UserName, user.UserRole, this.appSettings.Secret);

        }

        [HttpGet]
        [Route(nameof(Info))]
        public async Task<ActionResult<UserResponseModel>> Info()
        {
            var userId = this.User.GetId();

            return await this.identityService.GetUserInfo(userId);
        }

    }
}
