using System.Web.Mvc;
using System.Web.Routing;

namespace BlogApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Blog detail with category and title (SEO-friendly)
            routes.MapRoute(
                name: "DetailWithCategory",
                url: "detail/{category}/{id}",
                defaults: new { controller = "Home", action = "Detail" },
                constraints: new { id = @"\d+" }
            );

            // Category posts listing
            routes.MapRoute(
                name: "CategoryPosts",
                url: "category/{category}",
                defaults: new { controller = "Home", action = "Category" }
            );

            // Blog detail with id only (fallback)
            routes.MapRoute(
                name: "DetailById",
                url: "detail/{id}",
                defaults: new { controller = "Home", action = "Detail" },
                constraints: new { id = @"\d+" }
            );

            // Search results
            routes.MapRoute(
                name: "Search",
                url: "search/{query}",
                defaults: new { controller = "Home", action = "Search" }
            );

            // Tag posts
            routes.MapRoute(
                name: "TagPosts",
                url: "tag/{tag}",
                defaults: new { controller = "Home", action = "Tag" }
            );

            // Archive by year and month
            routes.MapRoute(
                name: "Archive",
                url: "archive/{year}/{month}",
                defaults: new { controller = "Home", action = "Archive", month = UrlParameter.Optional },
                constraints: new { year = @"\d{4}", month = @"\d{1,2}" }
            );

            // RSS Feed
            routes.MapRoute(
                name: "RssFeed",
                url: "rss",
                defaults: new { controller = "Home", action = "Rss" }
            );

            // Sitemap
            routes.MapRoute(
                name: "Sitemap",
                url: "sitemap.xml",
                defaults: new { controller = "Home", action = "Sitemap" }
            );

            // About page
            routes.MapRoute(
                name: "About",
                url: "about",
                defaults: new { controller = "Home", action = "About" }
            );

            // Contact page
            routes.MapRoute(
                name: "Contact",
                url: "contact",
                defaults: new { controller = "Home", action = "Contact" }
            );

            // Dashboard
            routes.MapRoute(
                name: "Dashboard",
                url: "dashboard",
                defaults: new { controller = "Dashboard", action = "Index" }
            );

            // Dashboard Posts
            routes.MapRoute(
                name: "DashboardPosts",
                url: "dashboard/posts",
                defaults: new { controller = "Dashboard", action = "Posts" }
            );

            // Dashboard Categories
            routes.MapRoute(
                name: "DashboardCategories",
                url: "dashboard/categories",
                defaults: new { controller = "Dashboard", action = "Categories" }
            );

            // Dashboard Tags
            routes.MapRoute(
                name: "DashboardTags",
                url: "dashboard/tags",
                defaults: new { controller = "Dashboard", action = "Tags" }
            );

            // Dashboard Comments
            routes.MapRoute(
                name: "DashboardComments",
                url: "dashboard/comments",
                defaults: new { controller = "Dashboard", action = "Comments" }
            );

            // Dashboard Users
            routes.MapRoute(
                name: "DashboardUsers",
                url: "dashboard/users",
                defaults: new { controller = "Dashboard", action = "Users" }
            );

            // Dashboard Statistics
            routes.MapRoute(
                name: "DashboardStatistics",
                url: "dashboard/statistics",
                defaults: new { controller = "Dashboard", action = "Statistics" }
            );

            // Dashboard Settings
            routes.MapRoute(
                name: "DashboardSettings",
                url: "dashboard/settings",
                defaults: new { controller = "Dashboard", action = "Settings" }
            );

            // Default route (en son)
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
