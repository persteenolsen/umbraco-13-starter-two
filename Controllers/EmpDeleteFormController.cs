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

public class EmpDeleteFormController : SurfaceController

{

    private readonly MvcAppDbContext _context;

    public EmpDeleteFormController(

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
    public IActionResult Submit(int? id)
    {
        var deleterecord = _context.Employees.Find(id);
        if (deleterecord == null)
        {
            // return NotFound();
            TempData["ResultOk"] = "Employee was not Deleted !";

            return RedirectToAction("EmpListFeedBack", "EmpList", new { area = "" });
        }
        _context.Employees.Remove(deleterecord);
        _context.SaveChanges();

        TempData["ResultOk"] = "Employee was Deleted Successfully !";

        //return RedirectToAction("Index");
         return RedirectToAction("EmpListFeedBack", "EmpList", new { area = "" });
      
      
       }


}