using SportsApp.Data.Models;
using System.Collections.Generic;

namespace PersonalBlog.Features.Search.Models
{
    public class SearchResponseModel
    {
        public IEnumerable<Player> Players { get; set; }

        public IEnumerable<Team> Teams { get; set; }
    }
}
