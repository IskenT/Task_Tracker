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
    public class TaskModelMethod : ITaskModelMethod
    {

        public async Task<TaskModel> AddTask(string name, string description, int projectId)
        {
            TaskModel task = new()
            {
                Name = name,
                Description = description,
                ProjectId = projectId
            };
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                await context.TaskModels.AddAsync(task);
                await context.SaveChangesAsync();
            }
            return task;
        }
        public async Task<TaskModel> UpdateTask(int id, string name, string description, int priority)
        {
            TaskModel task = new();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                task = context.TaskModels.FirstOrDefault(x => x.Id == id);
                if (task != null)
                {
                    task.Name = name;
                    task.Description = description;
                    task.Priority = priority;
                    context.Entry(task).State = EntityState.Modified;
                }
                await context.SaveChangesAsync();
            }
            return task;
        }
        public async Task<TaskModel> DeleteTask(int id)
        {
            TaskModel task = new();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                task = await context.TaskModels.FirstOrDefaultAsync(x => x.Id == id);
                if (task != null) context.TaskModels.Remove(task);
                await context.SaveChangesAsync();
            }
            return task;
        }
        public async Task<TaskModel> GetTaskById(int id)
        {
            TaskModel task = new();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
                task = await context.TaskModels.FirstOrDefaultAsync(x => x.Id == id);
            if (task != null) 
                return task;
            else 
                return null;
        }
        public async Task<List<TaskModel>> GetAllTasks()
        {
            List<TaskModel> tasks = new();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
                tasks = await context.TaskModels.ToListAsync();
            return tasks;
        }
        public async Task<List<TaskModel>> Search(string name)
        {
            
            using (var cont = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                var products = from p in cont.TaskModels
                               select p;

                if (name != null)
                {
                    products = from p in products
                               where p.Name.Contains(name)
                               select p;
                }
                return products.ToList();
            }
        }
    }
}
