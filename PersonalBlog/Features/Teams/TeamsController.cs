namespace PersonalBlog.Features.Articles
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PersonalBlog.Features.Articles.Models;
    using PersonalBlog.Features.Bases;
    using PersonalBlog.Infrastructure.Extensions;
    using PersonalBlog.Infrastructure.Filters;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static Infrastructure.Constants.AppConstants.RoutesContants;
     
    public class TeamsController : BaseAppController
    {
        private readonly TeamsService teamsService;


        public TeamsController(TeamsService teamsService)
        {
            this.teamsService = teamsService;
        }

        [HttpPost]
        [Authorize]
        [IsAdmin]
        [Route(nameof(Create))]

        public async Task<int> Create([FromForm] TeamRequestModel teamRequestModel)
        {
            var userId = this.User.GetId();
            var teamId = await this.teamsService.Create(teamRequestModel, userId);
            return teamId;
        }

        [HttpPut]
        [Authorize]
        [IsAdmin]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update([FromForm] TeamUpdateRequestModel teamUpdateRequestModel)
        {
            var userId = this.User.GetId();
            var isUpdateSuccessful = await this.teamsService.Update(teamUpdateRequestModel, userId);
            if (isUpdateSuccessful)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Authorize]
        [IsAdmin]
        [Route(DeleteByID)]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = this.User.GetId();


            var isDeletionSuccessful = await this.teamsService.Delete(id, userId);

            if (!isDeletionSuccessful)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        [Route(nameof(All))]
        public async Task<IEnumerable<TeamCollectionResponseModel>> All()
        {
            return await this.teamsService.GetAll();
        }

        [HttpGet]
        [Route(Id)]
        public async Task<TeamDetailsResponseModel> Get(int id)
        {
            return await this.teamsService.Get(id);
        }
    }
}
