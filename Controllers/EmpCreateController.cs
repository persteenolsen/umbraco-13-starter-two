using MvcUmbraco.Data;
using MvcUmbraco.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

using System.Collections.Generic;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace MvcUmbraco.Controllers
{
    // public class EmployeeController : Controller
    public class EmpCreateController : RenderController

    {
        private readonly MvcAppDbContext _context;

        public EmpCreateController(MvcAppDbContext context, ILogger<EmpCreateController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor)
        : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _context = context;

        }


        // 27-06-2025 - Using to show the Form for Create Employee
        // Here the Action = Document Type / Template Alias
        // Note: This is for the Umbraco Preview
        public IActionResult EmpCreate()
        {
            return View("EmpCreateForm");
        }

        // This route is hit by clicking a link 
        [Route("/emp-create")]
        public IActionResult Create()
        {

            // 28-06-2025 - A simulation used when testing frontend validation
            /*  Employee Emp = new Employee
               {
                   Id = 2,
                   Name = "Bo",
                   Designation = "Salesman",
                   Address = "Sweeden",
                   RecordCreatedOn = DateTime.Now

               };
               return View("EmpCreateForm", Emp);
               */

            return View("EmpCreateForm");

         }
    }
}
