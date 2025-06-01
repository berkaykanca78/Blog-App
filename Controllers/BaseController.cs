using BlogApp.Models;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace BlogApp.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
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
            
            base.OnActionExecuting(filterContext);
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