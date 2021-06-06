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
     
    public class PlayersController : BaseAppController
    {
        private readonly PlayersService playersService;


        public PlayersController(PlayersService playersService)
        {
            this.playersService = playersService;
        }

        [HttpPost]
        [Authorize]
        [IsAdmin]
        [Route(nameof(Create))]

        public async Task<int> Create([FromForm] PlayerRequestModel playerRequestModel)
        {
            var userId = this.User.GetId();
            var playerId = await this.playersService.Create(playerRequestModel, userId);
            return playerId;
        }

        [HttpPut]
        [Authorize]
        [IsAdmin]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update([FromForm] PlayerUpdateRequestModel playerUpdateRequestModel)
        {
            var userId = this.User.GetId();
            var isUpdateSuccessful = await this.playersService.Update(playerUpdateRequestModel, userId);
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

            var isDeletionSuccessful = await this.playersService.Delete(id, userId);

            if (!isDeletionSuccessful)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        [Route(nameof(All))]
        public async Task<IEnumerable<PlayerCollectionResponseModel>> All()
        {
            return await this.playersService.GetAll();
        }

        [HttpGet]
        [Route(Id)]
        public async Task<PlayerDetailsResponseModel> Get(int id)
        {
            return await this.playersService.Get(id);
        }
    }
}
