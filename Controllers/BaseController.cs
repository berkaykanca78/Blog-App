using BlogApp.Models;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace BlogApp.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Check if language is passed via query parameter (from localStorage)
            var requestedCulture = Request.QueryString["lang"];
            if (!string.IsNullOrEmpty(requestedCulture))
            {
                Session["Culture"] = requestedCulture;
            }
            
            // Set culture from session or default to Turkish
            var culture = Session["Culture"] as string ?? "tr-TR";
            SetCulture(culture);
            
            // Get categories for navigation menu
            var categories = db.Categories
                .OrderBy(c => c.Name)
                .Select(c => new CategoryViewModel 
                { 
                    Id = c.Id, 
                    Name = c.Name, 
                    Slug = c.Slug 
                })
                .ToList();

            ViewBag.NavigationCategories = categories;
            ViewBag.CurrentCulture = culture;
            
            base.OnActionExecuting(filterContext);
        }

        protected void SetCulture(string culture)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
} 