using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace habitsApp.Models
{
    public class Tasks
    {
        [Key]
        [Required]
        public int taskID { get; set; }

        [Required]
        public string TaskName { get; set; }

        public DateTime? DueDate { get; set; }

        [Range(1, 4)]
        [Required]
        public int Quadrant { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        public bool Completed { get; set; }
    }
}
