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
        public SearchService(PersonalBlogDbContext personalBlogDbContext) :base(personalBlogDbContext)
        {

        }

        public async Task<IEnumerable<ProjectSearchResponseModel>> GetSearchedProjects(ProjectSearchRequestModel projectSearchRequestModel)
        {
            return await this.personalBlogDbContext
                .Project
                .Where(p => p.Title.Contains(projectSearchRequestModel.Query) ||
                            p.ProjectTechnologies
                                .Any(pt => pt.Technology.Title.Contains(projectSearchRequestModel.Query)))
                .Select(p => new ProjectSearchResponseModel
                {
                    Title = p.Title,
                    Id = p.Id
                })
                .ToListAsync();
        }
    }
}
