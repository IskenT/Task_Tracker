using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker_API_3Tier.ViewModels;
using TaskTracker_BAL.Function;

namespace TaskTracker_API_3Tier.Contollers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : Controller
    {
        private TaskModelFunction taskModelFunction = new TaskModelFunction();
        //Add/create task in DB
        [Route("add")]
        [HttpPost]
        public async Task<Boolean> AddTask(string name, string description, int projectId)
        {
            bool result = await taskModelFunction.CreateNewTask(name, description, projectId);
            return result;
        }
        //Update task in DB
        [Route("update")]
        [HttpPut]
        public async Task<Boolean> UpdateTask (int id, string name, string description, int priority)
        {
            bool result = await taskModelFunction.UpdateTask(id, name, description, priority);
            return result;
        }

        //Delete task from DB
        [Route("delete")]
        [HttpDelete]
        public async Task<Boolean> DeleteTask (int id)
        {
            bool result = await taskModelFunction.DeleteTask(id);
            return result;
        }

        //Get one task with specific ID from DB
        [Route("show")]
        [HttpGet]
        public async Task<TaskModelView> GetTask(int id)
        {
            var task = await taskModelFunction.GetTaskById(id);
            TaskModelView currentTask = new TaskModelView
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Status = task.Status.ToString(),
                Priority = task.Priority
            };
            return currentTask;
        }
        [Route("show_all")]
        [HttpGet]

        //Get all tasks from DB
        public async Task<List<TaskModelView>> GetAllTasks()
        {
            List<TaskModelView> taskList = new List<TaskModelView>();
            var tasks = await taskModelFunction.GetAllTasks();
            if (tasks.Count > 0)
            {
                foreach (var task in tasks)
                {
                    TaskModelView currentTask = new TaskModelView
                    {
                        Id = task.Id,
                        Name = task.Name,
                        Description = task.Description,
                        Status = task.Status.ToString(),
                        Priority = task.Priority,
                        ProjectId = task.ProjectId,
                    };
                    taskList.Add(currentTask);
                }
            }
            return taskList;
        }
        //Get all tasks by name from DB
        [Route("search")]
        [HttpGet]
        public async Task<ActionResult<List<TaskModelView>>> Search(string name)
        {
            try
            {
                var result = await taskModelFunction.Search(name);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
