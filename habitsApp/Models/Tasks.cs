using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//Defining the Tasks model
namespace habitsApp.Models
{
    public class Tasks
    {
        //Requiring the ID, setting it to required, requiring Taskname, making datetime optional
        [Key]
        [Required]
        public int taskID { get; set; }

        [Required]
        public string TaskName { get; set; }

        public DateTime? DueDate { get; set; }

        //Setting the range and requiring a quadrant also breaking out category and making a model for that
        [Range(1, 4)]
        [Required]
        public int Quadrant { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        //Store completion
        public bool Completed { get; set; }
    }
}
