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
    public class EmpDeleteController : RenderController
   
    {
        private readonly MvcAppDbContext _context;

        public EmpDeleteController(MvcAppDbContext context, ILogger<EmpDeleteController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor)
        : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _context = context;
        }


        
        // [Route("/emp-delete/{id?}")]
        // 21-06-2025 - Note: I am only using the below Action for now in this Controller !!
        public IActionResult EmpDelete()
        //public override IActionResult Index()
        {
            int id = 0;
            // string idS = "";

            // 21-06-2025: Note - take id param from this url 
            // https://localhost:44317/emp-delete?id=5
            // There MUST be created a Document Type + Template with the names EditEmp equal the 
            // name of the Action EmpEdit(). The Content created using the Document Type + Template
            // have the url /emp-update and the TRICK is to link from Each Employee from the List to
            // the url emp-update?id=5 where 5 is an example of the Id of an Employee !
            // Note: Because of the below statement the url /emp-update will throw an error which should 
            // be taking care of or at lest hide the menu - item from the Menu
            string idS = HttpContext.Request.Query["id"].ToString();
                        
            Boolean res = false;
            int a;
            res = int.TryParse(idS, out a);
            if( res )
               id = int.Parse(idS);
                
            var empfromdb = _context.Employees.Find(id);

            if (empfromdb == null)
            {
                TempData["EmpDeleteResult"] = "Select an Employee from the List !";
                return View("EmpDeleteForm");
                //return RedirectToAction("Employees", "Employee", new { area = "" });
            } 

            // return View(empfromdb);
            return View("EmpDeleteForm", empfromdb);

        } 

    }
}
