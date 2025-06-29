using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging; 
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

using Microsoft.AspNetCore.Mvc;

using MvcUmbraco.Data;
using MvcUmbraco.Models;
namespace MvcUmbraco.Controllers;

public class EmpCreateFormController : SurfaceController

{

    private readonly MvcAppDbContext _context;

    public EmpCreateFormController(

        MvcAppDbContext context,
        IUmbracoContextAccessor umbracoContextAccessor,
        IUmbracoDatabaseFactory databaseFactory,
        ServiceContext services,
        AppCaches appCaches,
        IProfilingLogger profilingLogger,
        IPublishedUrlProvider publishedUrlProvider)

        : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
    {

        _context = context;

    }


    [HttpPost]
    // [ValidateAntiForgeryToken]
    //  [Route("/employees/edit/{id?}")]
    public IActionResult Submit(Employee empobj)
    {

        if (ModelState.IsValid)
        {

            var cdate = DateTime.Now;
            empobj.RecordCreatedOn = cdate;

            _context.Employees.Add(empobj);
            _context.SaveChanges();
            TempData["ResultOk"] = "Employee Added Successfully !";

            //return View("Employees");
            return RedirectToAction("EmpListFeedBack", "EmpList", new { area = "" });

        }

        TempData["ResultOk"] = "Employee was not Added !";

        // return View(empobj);
        //return View("Employees");
         return RedirectToAction("EmpListFeedBack", "EmpList", new { area = "" });
    }
        

}