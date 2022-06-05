using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_DAL.DataDBContext;
using TaskTracker_DAL.Interfaces;
using TaskTracker_DAL.Models;

namespace TaskTracker_DAL.Repositories
{
    public class ProjectModelMethod : IProjectModelMethod
    {
        public async Task<ProjectModel> Add (string name, int priority)
        {
            ProjectModel project = new()
            {
                Name = name,
                Priority = priority,
                StartDate = DateTime.Now,
                Status = ProjectStatus.NotStarted
            };
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                await context.ProjectModels.AddAsync(project);
                await context.SaveChangesAsync();
            }
            return project;
        }

        public async Task<ProjectModel> Update (int id, string name, int priority)
        {
            ProjectModel project = new();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                project = context.ProjectModels.FirstOrDefault(x => x.Id == id);
                if (project != null)
                {
                    project.Name = name;
                    project.Priority = priority;
                    context.Entry(project).State = EntityState.Modified;
                }
                await context.SaveChangesAsync();
            }
            return project;
        }

        public async Task<ProjectModel> Delete (int id)
        {
            ProjectModel project = new();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                project = await context.ProjectModels.FirstOrDefaultAsync(x => x.Id == id);
                if (project != null) context.ProjectModels.Remove(project);
                await context.SaveChangesAsync();
            }
            return project;
        }
        public async Task<ProjectModel> GetById(int id)
        {
            ProjectModel project = new();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
                project = await context.ProjectModels.FirstOrDefaultAsync(x => x.Id == id);
            if (project != null) 
                return project;
            else
                return null;
        }
        public async Task<List<ProjectModel>> GetAll()
        {
            List<ProjectModel> projects = new();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
                projects = await context.ProjectModels.ToListAsync();
            return projects;
        }
    }
}
