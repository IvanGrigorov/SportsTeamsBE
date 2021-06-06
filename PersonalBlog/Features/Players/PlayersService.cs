namespace PersonalBlog.Features.Articles
{
    using Microsoft.EntityFrameworkCore;
    using PersonalBlog.Data;
    using PersonalBlog.Data.Models;
    using PersonalBlog.Features.Articles.Models;
    using PersonalBlog.Features.Bases;
    using SportsApp.Data.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PlayersService : BaseApiService, IPlayersService
    {

        public PlayersService(SportsAppDbContext sportsAppDbContext) :base(sportsAppDbContext)
        {
        }

        public async Task<int> Create(PlayerRequestModel playerRequestModel, string userId)
        {
            var player = new Player
            {
                FirstName = playerRequestModel.FirstName,
                SecondName = playerRequestModel.SecondName,
                TeamId = playerRequestModel.TeamId,
                ImageUrl = playerRequestModel.ImageUrl,
                UserId = userId
            };

            this.sportsAppDbContext
                .Player
                .Add(player);

            await this.sportsAppDbContext.SaveChangesAsync();
            return player.Id;
        }

        public async Task<bool> Delete(int id, string userId)
        {
            var player = await this.GetByIdAndUserId(id, userId);
            if (player == null)
            {
                return false;
            }
            this.sportsAppDbContext.Remove(player);
            await this.sportsAppDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PlayerDetailsResponseModel> Get(int id)
        {
            return await this.sportsAppDbContext
                        .Player
                        .Where(a => a.Id == id)
                        .Select(a => new PlayerDetailsResponseModel
                        {
                            Id = a.Id,
                            FirstName = a.FirstName,
                            SecondName = a.SecondName,
                            ImageUrl = a.ImageUrl,
                            TeamId = a.TeamId,
                            TeamName = a.Team.Name
                        })
                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PlayerCollectionResponseModel>> GetAll()
        {
            return await this.sportsAppDbContext
                    .Player
                    .Select(a => new PlayerCollectionResponseModel
                    {
                        Id = a.Id,
                        Name = a.FirstName + " " + a.SecondName,
                        TeamName = a.Team.Name
                    })
                    .ToListAsync();
        }

        public async Task<bool> Update(PlayerUpdateRequestModel playerUpdateRequestModel, string userId)
        {
            var player = await this.GetByIdAndUserId(playerUpdateRequestModel.Id, userId);
            if (player == null)
            {
                return false;
            }
            player.FirstName = playerUpdateRequestModel.FirstName;
            player.SecondName = playerUpdateRequestModel.SecondName;
            player.TeamId = playerUpdateRequestModel.TeamId;
            player.ImageUrl = playerUpdateRequestModel.ImageUrl;


            await this.sportsAppDbContext.SaveChangesAsync();
            return true;

        }

        public async Task<Player> GetByIdAndUserId(int playerId, string userId)
        {
            return await this.sportsAppDbContext
                .Player
                .Where(a => a.Id == playerId && a.UserId == userId)
                .FirstOrDefaultAsync();
            
        }
    }
}
