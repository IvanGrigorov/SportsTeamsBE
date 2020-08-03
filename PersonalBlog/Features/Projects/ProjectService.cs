namespace PersonalBlog.Features.Projects
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualBasic;
    using Newtonsoft.Json.Linq;
    using PersonalBlog.Data;
    using PersonalBlog.Data.Models;
    using PersonalBlog.Features.Bases;
    using PersonalBlog.Features.Projects.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProjectService : BaseApiService, IProjectService
    {

        public ProjectService(PersonalBlogDbContext personalBlogDbContext) : base(personalBlogDbContext) 
        {
        }

        public async Task<int> CreateProject(ProjectRequestModel projectRequestModel, string userId)
        {
            var project = new Project()
            {
                Title = projectRequestModel.Title,
                Description = projectRequestModel.Description,
                UserId = userId,
                CreatedOn = projectRequestModel.CreatedOn
            };

            this.personalBlogDbContext.Add(project);

            await this.personalBlogDbContext.SaveChangesAsync();

            return project.Id;
        }

        public async Task<IEnumerable<ProjectCollectionServiceModel>> GetByUser(string userId)
        {
            return await this.personalBlogDbContext
                .Project
                .Where(p => p.UserId == userId)
                .Select(p => new ProjectCollectionServiceModel
                {
                    Id = p.Id,
                    Title = p.Title,

                })
                .ToListAsync();
        } 

        public async Task<ProjecDetailsServiceModel> GetProject(int id)
        {
            return await this.personalBlogDbContext
                .Project
                .Where(p => p.Id == id)
                .Select(p => new ProjecDetailsServiceModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    UserId = p.UserId,
                    UserName = p.User.UserName,
                    Technologies = p.ProjectTechnologies.Select(pt => pt.Technology),
                    Gallery = p.Gallery

                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProjectCollectionServiceModel>> GetAllProjects()
        {
            return await this.personalBlogDbContext
                .Project
                .Select(p => new ProjectCollectionServiceModel
                {
                    Id = p.Id,
                    Title = p.Title,

                })
                .ToListAsync();

        }

        public async Task<bool> DeleteProject(int projectId, string userId)
        {
            var project = await this.GetProjectByIdAndUserId(projectId, userId);

            if (project == null)
            {
                return false;
            }

            this.personalBlogDbContext.Remove(project);

            await this.personalBlogDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateProject(ProjectUpdateRequestModel projectUpdateRequestModel, string userId)
        {
            var project = await this.GetProjectByIdAndUserId(projectUpdateRequestModel.Id, userId);

            if (project == null)
            {
                return false;
            }

            project.Title = projectUpdateRequestModel.Title;
            project.Description = projectUpdateRequestModel.Description;

            await this.personalBlogDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Project> GetProjectByIdAndUserId(int projectId, string userId)
        {
            return await this.personalBlogDbContext
                .Project
                .Where(p => p.Id == projectId && p.UserId == userId)
                .FirstOrDefaultAsync();
        } 
    }
}
