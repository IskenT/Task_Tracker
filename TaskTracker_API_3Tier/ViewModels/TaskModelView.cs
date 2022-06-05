using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker_API_3Tier.ViewModels
{
    public class TaskModelView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public int ProjectId { get; set; }
    }
}
