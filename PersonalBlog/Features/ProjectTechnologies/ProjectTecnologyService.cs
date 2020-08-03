namespace PersonalBlog.Features.ProjectTechnologies
{
    using Microsoft.EntityFrameworkCore;
    using PersonalBlog.Data;
    using PersonalBlog.Data.Models;
    using PersonalBlog.Features.Bases;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProjectTecnologyService : BaseApiService, IProjectTecnologyService
    {


        public ProjectTecnologyService(PersonalBlogDbContext personalBlogDbContext) : base(personalBlogDbContext)
        {
        }

        public async Task AddProjectTechnologyMapping(int projectId, int[] technologyIds)
        {

            this.AddAllTechnologies(projectId, technologyIds);
            await this.personalBlogDbContext.SaveChangesAsync();

        }

        public async Task<bool> UpdateProjectTechnologies(int projectId, int[] technologyIds)
        {
            var projectTechnologies = await this.personalBlogDbContext
                .ProjectTechnology
                .Where(pt => pt.ProjectId == projectId)
                .ToListAsync();

            if (projectTechnologies == null)
            {
                return false;
            }
            foreach (var projectTechnology in projectTechnologies)
            {
                this.personalBlogDbContext.Remove(projectTechnology);
            }

            this.AddAllTechnologies(projectId, technologyIds);
            await this.personalBlogDbContext.SaveChangesAsync();
            return true;
        }

        public void AddAllTechnologies(int projectId, int[] technologyIds)
        {
            foreach (var technologyId in technologyIds)
            {
                var projectTechnology = new ProjectTechnology()
                {
                    ProjectId = projectId,
                    TechnologyId = technologyId
                };

                this.personalBlogDbContext.Add(projectTechnology);
            }
        }
    }
}
