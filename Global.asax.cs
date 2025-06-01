using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Globalization;
using System.Threading;
using System.Data.Entity;
using BlogApp.Models;

namespace BlogApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            // Database initialization - removed to prevent redirect loop
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, BlogApp.Migrations.Configuration>());
            
            // Set default culture for Turkish character support
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("tr-TR");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("tr-TR");
        }
        
        protected void Application_BeginRequest()
        {
            // Log all requests
            System.Diagnostics.Debug.WriteLine($"REQUEST: {Request.HttpMethod} {Request.Url.AbsolutePath}");
            
            // Ensure Turkish culture is set for each request
            Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr-TR");
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            
            // Log the error (you can implement logging here)
            System.Diagnostics.Debug.WriteLine($"Application Error: {exception?.Message}");
            System.Diagnostics.Debug.WriteLine($"Stack Trace: {exception?.StackTrace}");
            
            // Clear the error - but don't redirect
            Server.ClearError();
            
            // Don't redirect - this causes redirect loops
            // Response.Redirect("~/");
        }
    }
}
