
using Microsoft.EntityFrameworkCore;
using MvcUmbraco.Controllers;
using MvcUmbraco.Data;

// 20-06-2025 - Test
//using Umbraco.Cms.Web.Website.Controllers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


// This method will be called when making EF commands like migrations + update database
builder.Services.AddDbContext<MvcAppDbContext>(

    options => options.UseSqlite(

      builder.Configuration.GetConnectionString("efConnection")
      
      // 18-06-2025: This connection string DO NOT point to umbraco/Data !!
      // This is working by Powershell command:
      // dotnet ef database update --context MvcAppDbContext
      // "Data Source=Umbraco.sqlite.db;mode=ReadWrite;Cache=Private;Foreign Keys=True;Pooling=True"

  ));  


/*builder.Services.AddUmbracoDbContext<MvcAppDbContext>(options =>
{
    // options.UseSqlServer("{YOUR CONNECTIONSTRING HERE}");
    //If you are using SQlite, replace UseSqlServer with UseSqlite
    options.UseSqlite( builder.Configuration.GetConnectionString("umbracoDbDSN"));
        
}); */


builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
    .AddComposers()
    .Build();


WebApplication app = builder.Build();


// Note: Added to make the Umbraco Site more secure
app.Use(async (context, next) =>
{
    // Click-Jacking Protection
    // Checks if your site is allowed to be IFRAMEd by another site and 
    // then could be susceptible to click-jacking
    context.Response.Headers.Append("X-Frame-Options", "SAMEORIGIN");

    // Content/MIME Sniffing Protection
    context.Response.Headers.Append("X-Content-Type-Options", "nosniff");

    // Note: This header will make the Browser block the Bootstrap files 
    // and the layout of the Umbraco site will be lost
    // context.Response.Headers.Append("Content-Security-Policy", "img-src 'self' our.umbraco.com data: dashboard.umbraco.com; default-src 'self' our.umbraco.com marketplace.umbraco.com; script-src 'self'; style-src 'unsafe-inline' 'self'; font-src 'self'; connect-src 'self'; frame-src 'self'; ");
    
    await next();
});

// Note: Added to make the Umbraco Site more secure
// Protects for Cookie hijacking and protocol downgrade attacks
// Strict-Transport-Security Header (HSTS) is only used for Production when using HTTPS
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}


await app.BootUmbracoAsync();


app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseInstallerEndpoints();
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();

        // 20-06-2025 - TEST
        // Iqual Route implemented in EmployeeController as Anotation
       // u.EndpointRouteBuilder.MapControllerRoute("Employee Controller", "employees/edit/{id}", new { Controller = "Employee", Action = "Edit" });
    });

await app.RunAsync();
