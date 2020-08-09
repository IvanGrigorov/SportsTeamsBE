namespace PersonalBlog.Features.Projects
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PersonalBlog.Features.Galleries;
    using PersonalBlog.Features.Galleries.Models;
    using PersonalBlog.Features.Navigation;
    using PersonalBlog.Features.Projects.Models;
    using PersonalBlog.Features.ProjectTechnologies;
    using PersonalBlog.Infrastructure.Extensions;
    using PersonalBlog.Infrastructure.Filters;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static Infrastructure.Constants.AppConstants.RoutesContants;


    public class ProjectController : ProgrammingAppController
    {

        private readonly IProjectService projectService;
        private readonly IProjectTecnologyService projectTecnologyService;
        private readonly IGalleryService galleryService;




        public ProjectController(IProjectService projectService, IProjectTecnologyService projectTecnologyService, IGalleryService galleryService)
        {
            this.projectService = projectService;
            this.projectTecnologyService = projectTecnologyService;
            this.galleryService = galleryService;

        }

        [Authorize]
        [IsAdmin]
        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<int>> Create([FromForm] ProjectRequestModel projectModel)
        {
            var userId = this.User.GetId();

            var projectId = await this.projectService.CreateProject(projectModel, userId);

            await this.projectTecnologyService.AddProjectTechnologyMapping(projectId, projectModel.Technologies);
            if (projectModel.Gallery.Count() > 0)
            {
                var galleryMaperObject = new GalleryMapperObject
                {
                    ProjectId = projectId
                };
                await this.galleryService.ObtainMultipleFiles(projectModel.Gallery, galleryMaperObject);

            }
            return Created(nameof(Create), projectId);

        }

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<ProjecDetailsServiceModel>> Project(int id)
        {
            var project = await this.projectService.GetProject(id);

            return project;

        }

        [Authorize]
        [HttpGet]
        [Route(nameof(GetProjects))]
        public async Task<IEnumerable<ProjectCollectionServiceModel>> GetProjects()
        {
            var userId = this.User.GetId();

            var project = await this.projectService.GetByUser(userId);

            return project;

        }

        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<IEnumerable<ProjectCollectionServiceModel>> GetAll()
        {
            var project = await this.projectService.GetAllProjects();

            return project;

        }

        [Authorize]
        [HttpDelete]
        [Route(DeleteByID)]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = this.User.GetId();

            var galleryMapperObject = new GalleryMapperObject
            {
                ProjectId = id
            };

            var files = await this.galleryService.ReturnFilesForDeletion(galleryMapperObject);

            var isDeletionSuccessful = await this.projectService.DeleteProject(id, userId);

            if (!isDeletionSuccessful)
            {
                return BadRequest();
            }

            // await this.galleryService.DeleteImageFromDB(files);
            this.galleryService.DeleteImageFromFileStorage(files);

            return Ok();
        }

        [Authorize]
        [IsAdmin]
        [HttpPut]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update([FromForm] ProjectUpdateRequestModel projectUpdateRequestModel)
        {
            var userId = this.User.GetId();

            var isProjectUpdateSuccessful = await this.projectService.UpdateProject(projectUpdateRequestModel, userId);
            var isProjectTechnologiesUpdateSuccessful = await this.projectTecnologyService.UpdateProjectTechnologies(projectUpdateRequestModel.Id, projectUpdateRequestModel.Technologies);
            if (!isProjectUpdateSuccessful || !isProjectTechnologiesUpdateSuccessful)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
