using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker_DAL.Models;

namespace TaskTracker_DAL.Interfaces
{
    public interface IProjectModelMethod
    {
        Task<ProjectModel> Add (string name, int priority);
        Task<ProjectModel> Update (int id, string name, int priority);
        Task<ProjectModel> Delete (int id);       
        Task<ProjectModel> GetById(int id);
        Task<List<ProjectModel>> GetAll ();
    }
}
