namespace PersonalBlog.Features.Articles
{
    using PersonalBlog.Data.Models;
    using PersonalBlog.Features.Articles.Models;
    using SportsApp.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPlayersService
    {
        public Task<int> Create(PlayerRequestModel articleRequestModel, string userId);

        public Task<bool> Delete(int id, string userId);

        public Task<bool> Update(PlayerUpdateRequestModel articleUpdateRequestModel, string userId);

        public Task<IEnumerable<PlayerCollectionResponseModel>> GetAll();

        public Task<PlayerDetailsResponseModel> Get(int id);

        public Task<Player> GetByIdAndUserId(int playerId, string userId);



    }
}
