
/*
© 2023 IS Junor Core Group 01-14
ASP.NET controller for habitsApp
Author: Isaac Waddell

NOTE: labels shown for each of the Create, Read, Update, and Delete functionalities, e.g.
"
C { ––––––––––––––––––––
} ––––––––––––––––––––––
"
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using habitsApp.Models;

namespace habitsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // ASSUMPTION: 'TaskCtxt' will be the name of the class as created in the 'habitsApp.Models' namespace
        private TaskCtxt _taskCtxt { get; set; }

        public HomeController(ILogger<HomeController> logger, TaskCtxt taskCtxt)
        {
            _logger = logger;

            // the private variable as it will be initialized in the constructor for 'HomeController'
            _taskCtxt = taskCtxt;
        }

// R { –––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––

        public IActionResult Index() {
            var tasks = _tastkCtxt.tasks.ToList();
            return View(tasks);
        }

// } –––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––

        public IActionResult Index()
        {
            var tasks = _tastkCtxt.tasks.ToList();
            return View(tasks);
        }

        // } –––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––

        /*
        NOTES ON 'ViewBag':
            - the 'pageTitle' variable can be used to set some text in the view (not necessary, so let me know)
            - the 'formAction' should be used in the view's 'form' element's 'asp-action' attribute;
                - this facilitates various processes since we can:
                    1. change which action is triggered dynamically and therefore
                    2. use the same view for both adding and updating records
                - this can be done by referencing the object (and its attributes) in the cshtml file,
                  e.g. '@ViewBag.pageTitle'
        */
        // C { –––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
        // ASSUMPTION: 'Task' view will exist for both adding and editing (updating) records
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.categories = _taskCtxt.categories.ToList();
            ViewBag.pageTitle = "Add";
            // 'formAction' here will be set to 'add' so that the 'Add' post action (see below) is triggered
            // this is an example of what's described above in the 'NOTES ON ViewBag'
            ViewBag.formAction = "Add";
            return View("Task");
        }

        [HttpPost]
        public IActionResult Add(Tasks task) {
            if (ModelState.IsValid) {
                _taskCtxt.Add(task);
                _taskCtxt.SaveChanges();
                return View("Index");
            }
            else { return View("Task", task); }
        }

// } –––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––

// U { –––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––

        [HttpGet]
        public IActionResult Edit(int taskID)
        {
            var task = _taskCtxt.tasks.Single(t => t.taskID == taskID);
            ViewBag.categories = _taskCtxt.categories.ToList();
            ViewBag.pageTitle = "Edit";
            ViewBag.formAction = "Edit";
            return View("Task", task);
        }

        [HttpPost]
        public IActionResult Edit(Tasks task) {
            if (ModelState.IsValid) {
                _taskCtxt.Update(task);
                _taskCtxt.SaveChanges();
                return View("Index");
            }
            else
            {
                ViewBag.categories = _taskCtxt.categories.ToList();
                return View(task);
            }
        }
        // } –––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––

        // D { –––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
        [HttpGet]
        public IActionResult Delete(int taskID) {
            var task = _taskCtxt.tasks.Single(t => t.taskID == taskID);
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(Tasks task) {
            _taskCtxt.Remove(task);
            _taskCtxt.SaveChanges();
            return View("Index");
        }
        // } –––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
