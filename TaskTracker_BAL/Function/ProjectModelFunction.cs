using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_DAL.Interfaces;
using TaskTracker_DAL.Models;

namespace TaskTracker_BAL.Function
{
    public class ProjectModelFunction
    {
        private IProjectModelMethod _projectModel = new TaskTracker_DAL.Repositories.ProjectModelMethod();

        public async Task<Boolean> CreateNew (string name, int priority)
        {
            try
            {
                var project = await _projectModel.Add(name, priority);

                if (project.Id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<Boolean> Update(int id, string name, int priority)
        {
            try
            {
                var  project = await _projectModel.Update(id, name, priority);

                if (project.Id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<Boolean> Delete(int id)
        {
            try
            {
                var project = await _projectModel.Delete(id);

                if (project.Id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
        public async Task<ProjectModel> GetProjectById(int id)
        {
            var project = await _projectModel.GetById(id);
            return project;
        }
        public async Task<List<ProjectModel>> GetAllProjects()
        {
            List<ProjectModel> projects = await _projectModel.GetAll();
            return projects;
        }  
        
    }
}
