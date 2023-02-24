using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace habitsApp.Models
{
    public class TaskCtxt : DbContext
    {
        public TaskCtxt(DbContextOptions<TaskCtxt> options) : base(options)
        {

        }

        public DbSet<Tasks> tasks { get; set; }
        public DbSet<Category> categories { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryDesc = "Home"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryDesc = "School"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryDesc = "Work"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryDesc = "Church"
                }
                );

        }
    }
}
