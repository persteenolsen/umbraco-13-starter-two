using MvcUmbraco.Data;
using MvcUmbraco.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;


using System.Collections.Generic;
using System.Linq;
using System;

namespace MvcUmbraco.Controllers
{
    // public class EmployeeController : Controller
    public class EmpListController : RenderController

    {
        private readonly MvcAppDbContext _context;

        public EmpListController(MvcAppDbContext context, ILogger<EmpListController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor)
        : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _context = context;
        }

        // 28-06-2025 - Using for display the List of Employees !
        // Note: There need to be both a Documentent Type + Template + Content Node with the names EmpList 
        // This Action will be called by using:
        // 1) Umbraco Preview of the List of Employees ( EmpList )
        // 2) The Menu Link: /list-of-employees/ or whatever Content Node of ( EmPList )
        public IActionResult EmpList()
        {
            // The Employees will be in the IEnumerable of Employees
            IEnumerable<Employee> objCatlist = _context.Employees;

            // 26-06-2025: The loop is not used for now !
            // TempData["Employees"] = "";
            using (IEnumerator<Employee> empEnumerator = objCatlist.GetEnumerator())
            {
                while (empEnumerator.MoveNext())
                {
                    // now empEnumerator.Current is the Employee instance without casting
                    Employee emp = empEnumerator.Current;

                    // Arrange the layout and structure of the Employees to be passed to the View
                    //  TempData["Employees"] += "Name: " + emp.Name;
                }
            }

            // The IEnumerable of Employees will be ready in the View as ViewData
            ViewData["EmployeeData"] = objCatlist;

            // Pass the Employees by model
            // return View(objCatlist);
            return View();
        } 

        // 28-06-2025 - Display the List of Employees as User Feed Back after CRUD !
        [Route("/emp-list-feed-back")]
        public IActionResult EmpListFeedBack()
        {
            // The Employees will be in the IEnumerable of Employees
            IEnumerable<Employee> objCatlist = _context.Employees;

            // The IEnumerable of Employees will be ready in the View as ViewData
            ViewData["EmployeeData"] = objCatlist;

            // Pass the Employees by model
            // return View(objCatlist);
             return View("EmpList");
        } 


        // 28-06-2025 - Simulation of the List of Employees from the SQLite DB
        // [Route("/emp-list-feed-back")]
       /*  public IActionResult EmpList()
        {
            List<Employee> emp = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Chris",
                    Designation = "Clerk",
                    Address = "Denmark",
                    RecordCreatedOn = DateTime.Now

                },
                new Employee
                {
                    Id = 2,
                    Name = "Bo",
                    Designation = "Salesman",
                    Address = "Sweeden",
                    RecordCreatedOn = DateTime.Now

                },
                new Employee
                {
                    Id = 3,
                    Name = "Luis",
                    Designation = "Barman",
                    Address = "Norway",
                    RecordCreatedOn = DateTime.Now

                }
            };

            ViewData["EmployeeData"] = emp;

             return View();
            //return View("Employees", emp);
            }
        */
    }
}
