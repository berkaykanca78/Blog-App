using BlogApp.Contexts;
using BlogApp.Models;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

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
                    Name = culture == "tr-TR" ? c.Name : c.EnglishName, 
                    Slug = culture == "tr-TR" ? c.Slug : c.EnglishSlug
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