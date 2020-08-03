namespace PersonalBlog.Features.Technologies
{
    using Microsoft.EntityFrameworkCore;
    using PersonalBlog.Data;
    using PersonalBlog.Data.Models;
    using PersonalBlog.Features.Bases;
    using PersonalBlog.Features.Technologies.Model;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TechnologyService : BaseApiService, ITechologyService
    {

        public TechnologyService(PersonalBlogDbContext personalBlogDbContext) : base(personalBlogDbContext)
        {
        }

        public async Task<int> CreateTechnology(TechnologyRequestModel technologyRequestModel)
        {
            var technology = new Technology()
            {
                Title = technologyRequestModel.Title,
                Description = technologyRequestModel.Description,
            };

            this.personalBlogDbContext.Add(technology);

            await this.personalBlogDbContext.SaveChangesAsync();

            return technology.Id;
        }

        public async Task<bool> DeleteTechnology(int technologyId)
        {
            var technology = await this.GetTechnologyById(technologyId);

            if (technology == null)
            {
                return false;
            }

            this.personalBlogDbContext.Remove(technology);

            await this.personalBlogDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TechnologyResponseModel>> GetAllTechnologies()
        {
            return await this.personalBlogDbContext
                    .Technology
                    .Select(t => new TechnologyResponseModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description

                    })
                    .ToListAsync();
        }

        public async Task<Technology> GetTechnologyById(int technologyId)
        {
            return await this.personalBlogDbContext
                            .Technology
                            .Where(t => t.Id == technologyId)
                            .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateTechnology(TechnologyUpdateRequestModel technologyUpdateRequestModel)
        {
            var technology = await this.GetTechnologyById(technologyUpdateRequestModel.Id);

            if (technology == null)
            {
                return false;
            }

            technology.Title = technologyUpdateRequestModel.Title;
            technology.Description = technologyUpdateRequestModel.Description;

            await this.personalBlogDbContext.SaveChangesAsync();

            return true;
        }
    }
}
