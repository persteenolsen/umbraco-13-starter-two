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


        // 22-06-2025 - Using to show the Form for Create Employee
        // Note: The must be a Umbraco Content Node with the same Route for every Route defined here
        // // to map to the Action / Controller
        [Route("/emp-create")]
        [Route("/create-an-employee")]
        public IActionResult Create()
        {
            // return View();
            return View("EmpCreateForm");
        }
    }
}
