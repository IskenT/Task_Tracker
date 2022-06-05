using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_DAL.Models;

namespace TaskTracker_DAL.Interfaces
{
    public interface ITaskModelMethod
    {
        Task<TaskModel> AddTask(string name, string description, int projectId);
        Task<TaskModel> UpdateTask(int id, string name, string description, int priority);
        Task<TaskModel> DeleteTask(int id);
        Task<TaskModel> GetTaskById(int id);
        Task<List<TaskModel>> GetAllTasks();
        Task<List<TaskModel>> Search(string name);
    }
}
