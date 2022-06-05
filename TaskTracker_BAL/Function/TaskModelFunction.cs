


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker_DAL.Interfaces;
using TaskTracker_DAL.Models;

namespace TaskTracker_BAL.Function
{
    public class TaskModelFunction 
    {
        private ITaskModelMethod _taskModel = new TaskTracker_DAL.Repositories.TaskModelMethod();
        public async Task<Boolean> CreateNewTask(string name, string description, int projectId)
        {
            try
            {
                var result = await _taskModel.AddTask(name, description, projectId);

                if (result.Id > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                string err = e.Message;
                return false;
            }
        }

        public async Task<Boolean> UpdateTask(int id, string name, string description, int priority)
        {
            try
            {
                var result = await _taskModel.UpdateTask(id, name, description, priority);

                if (result.Id > 0)
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
        public async Task<Boolean> DeleteTask(int id)
        {
            try
            {
                var result = await _taskModel.DeleteTask(id);

                if (result.Id > 0)
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

        public async Task<TaskModel> GetTaskById(int id)
        {
            var task = await _taskModel.GetTaskById(id);
            return task;
        }
        public async Task<List<TaskModel>> GetAllTasks()
        {
            List<TaskModel> tasks = await _taskModel.GetAllTasks();
            return tasks;
        }
        public async Task<List<TaskModel>> Search(string name)
        {
            List<TaskModel> query = await _taskModel.Search(name);
            return query;
        }
    }
}
