using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class DashboardController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Dashboard";
            ViewBag.NavigationPage = "Dashboard";
            return View();
        }

        public ActionResult Posts()
        {
            ViewBag.Title = "Yazılar";
            ViewBag.NavigationPage = "Posts";
            return View();
        }

        public ActionResult Categories()
        {
            ViewBag.Title = "Kategoriler";
            ViewBag.NavigationPage = "Categories";
            return View();
        }

        public ActionResult Tags()
        {
            ViewBag.Title = "Etiketler";
            ViewBag.NavigationPage = "Tags";
            return View();
        }

        public ActionResult Comments()
        {
            ViewBag.Title = "Yorumlar";
            ViewBag.NavigationPage = "Comments";
            return View();
        }

        public ActionResult Users()
        {
            ViewBag.Title = "Kullanıcılar";
            ViewBag.NavigationPage = "Users";
            return View();
        }

        public ActionResult Statistics()
        {
            ViewBag.Title = "İstatistikler";
            ViewBag.NavigationPage = "Statistics";
            return View();
        }

        public ActionResult Settings()
        {
            ViewBag.Title = "Ayarlar";
            ViewBag.NavigationPage = "Settings";
            return View();
        }
    }
} 