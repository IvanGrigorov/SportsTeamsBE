namespace PersonalBlog.Features.Articles
{
    using PersonalBlog.Data.Models;
    using PersonalBlog.Features.Articles.Models;
    using SportsApp.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITeamsService
    {
        public Task<int> Create(TeamRequestModel teamRequestModel, string userId);

        public Task<bool> Delete(int id, string userId);

        public Task<bool> Update(TeamUpdateRequestModel teamUpdateRequestModel, string userId);

        public Task<IEnumerable<TeamCollectionResponseModel>> GetAll();

        public Task<TeamDetailsResponseModel> Get(int id);

        public Task<Team> GetByIdAndUserId(int teamId, string userId);



    }
}
