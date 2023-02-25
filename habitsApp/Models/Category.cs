using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace habitsApp.Models
{
    public class Category
    {
        //Requiring a primary ID and giving an optional Description
        [Required]
        [Key]
        public int CategoryId { get; set; }
        public string CategoryDesc { get; set; }

    }
}
