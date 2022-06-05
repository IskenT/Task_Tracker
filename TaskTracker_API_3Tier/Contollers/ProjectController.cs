using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker_API_3Tier.ViewModels;
using TaskTracker_BAL.Function;

namespace TaskTracker_API_3Tier.Contollers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : Controller
    {
        private ProjectModelFunction projectModelFunction = new ProjectModelFunction();
        //Add/create project in DB
        [Route("add")]
        [HttpPost]
        public async Task<Boolean> Create (string name, int priority)
        {
            bool result = await projectModelFunction.CreateNew(name, priority);
            return result;
        }
        //Update project in DB
        [Route("update")]
        [HttpPut]
        public async Task<Boolean> Update (int id, string name, int priority)
        {
            bool result = await projectModelFunction.Update(id, name, priority);
            return result;
        }

        //Delete project from DB
        [Route("delete")]
        [HttpDelete]
        public async Task<Boolean> Delete (int id)
        {
            bool result = await projectModelFunction.Delete(id);
            return result;
        }
        //Get one project with specific ID from DB
        [Route("show")]
        [HttpGet]
        public async Task<ProjectModelView> GetProject(int id)
        {
            var project = await projectModelFunction.GetProjectById(id);
            ProjectModelView currentProject = new ProjectModelView
            {
                Id = project.Id,
                Name = project.Name,
                Status = project.Status.ToString(),
                Priority = project.Priority
            };
            return currentProject;
        }

        //Get all projects from DB
        [Route("show_all")]
        [HttpGet]
        public async Task<List<ProjectModelView>> GetAllProjects()
        {
            List<ProjectModelView> listOfProjects = new List<ProjectModelView>();
            var projects = await projectModelFunction.GetAllProjects();
            if (projects.Count > 0)
            {
                foreach (var project in projects)
                {
                    ProjectModelView currentProject = new ProjectModelView
                    {
                        Id = project.Id,
                        Name = project.Name,
                        Status = project.Status.ToString(),
                        Priority = project.Priority,
                    };
                    listOfProjects.Add(currentProject);
                }
            }
            return listOfProjects;
        }
    }
}
