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

    public class TeamsService : BaseApiService, ITeamsService
    {

        public TeamsService(SportsAppDbContext sportsAppDbContext) :base(sportsAppDbContext)
        {
        }

        public async Task<int> Create(TeamRequestModel teamRequestModel, string userId)
        {
            var team = new Team
            {
                Name = teamRequestModel.TeamName,
                ImageUrl = teamRequestModel.ImageUrl,
                UserId = userId
            };

            this.sportsAppDbContext
                .Team
                .Add(team);

            await this.sportsAppDbContext.SaveChangesAsync();
            return team.Id;
        }

        public async Task<bool> Delete(int id, string userId)
        {
            var team = await this.GetByIdAndUserId(id, userId);
            if (team == null)
            {
                return false;
            }
            this.sportsAppDbContext.Remove(team);
            await this.sportsAppDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<TeamDetailsResponseModel> Get(int id)
        {
            return await this.sportsAppDbContext
                        .Team
                        .Where(a => a.Id == id)
                        .Select(a => new TeamDetailsResponseModel
                        {
                            Id = a.Id,
                            TeamName = a.Name,
                            Players = a.Players,
                            ImageUrl = a.ImageUrl,
                        })
                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TeamCollectionResponseModel>> GetAll()
        {
            return await this.sportsAppDbContext
                    .Team
                    .Select(a => new TeamCollectionResponseModel
                    {
                        Id = a.Id,
                        TeamName = a.Name
                    })
                    .ToListAsync();
        }

        public async Task<bool> Update(TeamUpdateRequestModel teamUpdateRequestModel, string userId)
        {
            var team = await this.GetByIdAndUserId(teamUpdateRequestModel.Id, userId);
            if (team == null)
            {
                return false;
            }
            team.Name = teamUpdateRequestModel.TeamName;
            team.ImageUrl = teamUpdateRequestModel.ImageUrl;

            await this.sportsAppDbContext.SaveChangesAsync();
            return true;

        }

        public async Task<Team> GetByIdAndUserId(int teamId, string userId)
        {
            return await this.sportsAppDbContext
                .Team
                .Where(a => a.Id == teamId && a.UserId == userId)
                .FirstOrDefaultAsync();
            
        }
    }
}
