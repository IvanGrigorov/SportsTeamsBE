namespace PersonalBlog.Features.Search
{
    using Microsoft.EntityFrameworkCore;
    using PersonalBlog.Data;
    using PersonalBlog.Features.Bases;
    using PersonalBlog.Features.Search.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SearchService : BaseApiService, ISearchService
    {
        public SearchService(SportsAppDbContext sportsAppDbContext) :base(sportsAppDbContext)
        {

        }

        public async Task<SearchResponseModel> GetSearchedItems(SearchRequestModel searchRequestModel)
        {

             var teams = await this.sportsAppDbContext
                .Team
                .Where(t => t.Name.Contains(searchRequestModel.Query))
                .ToListAsync();

            var players = await this.sportsAppDbContext
                .Player
                .Where(p => p.FirstName.Contains(searchRequestModel.Query) ||
                            p.SecondName.Contains(searchRequestModel.Query))
                .ToListAsync();

            return new SearchResponseModel
            {
                Players = players,
                Teams = teams
            };
        }
    }
}
