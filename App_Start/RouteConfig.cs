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
                url: "detay/{category}/{id}",
                defaults: new { controller = "Home", action = "Detail" },
                constraints: new { id = @"\d+" }
            );

            // Category posts listing
            routes.MapRoute(
                name: "CategoryPosts",
                url: "kategori/{category}",
                defaults: new { controller = "Home", action = "Category" }
            );

            // Blog detail with id only (fallback)
            routes.MapRoute(
                name: "DetailById",
                url: "detay/{id}",
                defaults: new { controller = "Home", action = "Detail" },
                constraints: new { id = @"\d+" }
            );

            // Search results
            routes.MapRoute(
                name: "Search",
                url: "ara/{query}",
                defaults: new { controller = "Home", action = "Search" }
            );

            // Tag posts
            routes.MapRoute(
                name: "TagPosts",
                url: "etiket/{tag}",
                defaults: new { controller = "Home", action = "Tag" }
            );

            // Archive by year and month
            routes.MapRoute(
                name: "Archive",
                url: "arsiv/{year}/{month}",
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
                url: "hakkinda",
                defaults: new { controller = "Home", action = "About" }
            );

            // Contact page
            routes.MapRoute(
                name: "Contact",
                url: "iletisim",
                defaults: new { controller = "Home", action = "Contact" }
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
