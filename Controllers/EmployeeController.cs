using MvcUmbraco.Data;
using MvcUmbraco.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;


using System.Collections.Generic;
using System.Linq;

namespace MvcUmbraco.Controllers
{
   // public class EmployeeController : Controller
    public class EmployeeController : RenderController
   
    {
        private readonly MvcAppDbContext _context;

        public EmployeeController(MvcAppDbContext context, ILogger<EmployeeController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor)
        : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
                 _context = context;
            }

       // 22-06-2025 - Using for display the List of Employees !
        [Route("/employees")]
        public IActionResult Employees()
        {
            IEnumerable<Employee> objCatlist = _context.Employees;

            TempData["Employees"] = "";

            using (IEnumerator<Employee> empEnumerator = objCatlist.GetEnumerator())
            {
                while (empEnumerator.MoveNext())
                {
                    // now empEnumerator.Current is the Employee instance without casting
                    Employee emp = empEnumerator.Current;

                    // Arrange the layout and structure of the Employees to be passed to the View
                    TempData["Employees"] += "Name: " + emp.Name;

                }
            }

            // Note: Use with Master.cshtml !
            // Using a modified layout MasterMVC.cshtml to avoid an error
            // Pass the Employees by model
            return View(objCatlist);

           // Note: Use with Master.cshtml !
           // Pass the Employees by TempData["Employees"]
           // return View();

        }


    }
}
