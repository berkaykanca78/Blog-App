using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(int page = 1, int pageSize = 4)
        {
            var posts = db.Posts
                .Include(p => p.Category)
                .OrderByDescending(p => p.CreatedAt)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPosts = posts.Count;
            ViewBag.NavigationPage = "Index"; 

            return View(posts);
        }

        public ActionResult Detail(int id, string category = null)
        {
            var post = db.Posts
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return HttpNotFound();
            }

            var expectedCategorySlug = GenerateSlug(post.Category?.Name ?? "genel");

            if (!string.IsNullOrEmpty(category))
            {
                if (category.ToLower() != expectedCategorySlug.ToLower())
                {
                    return RedirectToRoute("DetailWithCategory", new { 
                        category = expectedCategorySlug, 
                        id = id, 
                    });
                }
            }

            var relatedPosts = db.Posts
                .Include(p => p.Category)
                .Where(p => p.Id != id && p.CategoryId == post.CategoryId)
                .OrderByDescending(p => p.CreatedAt)
                .Take(3)
                .ToList();

            if (!relatedPosts.Any())
            {
                relatedPosts = db.Posts
                    .Include(p => p.Category)
                    .Where(p => p.Id != id)
                    .OrderByDescending(p => p.CreatedAt)
                    .Take(3)
                    .ToList();
            }

            // Yorumları çek (sadece ana yorumlar, yanıtları ile birlikte)
            var comments = db.Comments
                .Include(c => c.Replies)
                .Where(c => c.PostId == id && c.ParentCommentId == null)
                .OrderByDescending(c => c.CreatedAt)
                .ToList();

            var culture = Session["Culture"] as string ?? "tr-TR";

            ViewBag.RelatedPosts = relatedPosts;
            ViewBag.Comments = comments;
            ViewBag.CurrentPage = "Detail";
            ViewBag.CurrentCategory = culture == "tr-TR" ? post.Category?.Slug : post.Category?.EnglishSlug;
            ViewBag.Title = $"{post.Title} - Blog";
            ViewBag.PostId = id;

            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(int postId, string name, string email, string content, int? parentCommentId = null)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(content))
                {
                    return Json(new { success = false, message = "Tüm alanları doldurmanız gerekiyor." });
                }

                if (content.Length > 500)
                {
                    return Json(new { success = false, message = "Yorum 500 karakterden uzun olamaz." });
                }

                // Check if post exists
                var post = db.Posts.Find(postId);
                if (post == null)
                {
                    return Json(new { success = false, message = "Blog yazısı bulunamadı." });
                }

                // If it's a reply, check if parent comment exists
                if (parentCommentId.HasValue)
                {
                    var parentComment = db.Comments.Find(parentCommentId.Value);
                    if (parentComment == null)
                    {
                        return Json(new { success = false, message = "Yanıtlanacak yorum bulunamadı." });
                    }
                }

                // Create new comment
                var comment = new Comment
                {
                    PostId = postId,
                    Name = name.Trim(),
                    Email = email.Trim(),
                    Content = content.Trim(),
                    ParentCommentId = parentCommentId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                db.Comments.Add(comment);

                // Update post comment count (only for main comments, not replies)
                if (!parentCommentId.HasValue)
                {
                    post.CommentCount = db.Comments.Count(c => c.PostId == postId && c.ParentCommentId == null) + 1;
                }

                db.SaveChanges();

                return Json(new { success = true, message = "Yorumunuz başarıyla gönderildi!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Bir hata oluştu. Lütfen tekrar deneyin." });
            }
        }

        [HttpPost]
        public ActionResult LikePost(int postId)
        {
            try
            {
                var post = db.Posts.Find(postId);
                if (post == null)
                {
                    return Json(new { success = false, message = "Blog yazısı bulunamadı." });
                }

                post.LikeCount++;
                db.SaveChanges();

                return Json(new { success = true, newLikeCount = post.LikeCount });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Bir hata oluştu." });
            }
        }

        [HttpPost]
        public ActionResult LikeComment(int commentId)
        {
            try
            {
                var comment = db.Comments.Find(commentId);
                if (comment == null)
                {
                    return Json(new { success = false, message = "Yorum bulunamadı." });
                }

                comment.LikeCount++;
                db.SaveChanges();

                return Json(new { success = true, newLikeCount = comment.LikeCount });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Bir hata oluştu." });
            }
        }

        public ActionResult Category(string category, int page = 1, int pageSize = 8)
        {
            var categoryEntity = db.Categories.FirstOrDefault(c => c.Slug.ToLower() == category.ToLower() || c.EnglishSlug.ToLower() == category.ToLower());

            if (categoryEntity == null)
            {
                return HttpNotFound();
            }

            var posts = db.Posts
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryEntity.Id)
                .OrderByDescending(p => p.CreatedAt)
                .ToList();

            var culture = Session["Culture"] as string ?? "tr-TR";

            ViewBag.CategoryName = culture == "tr-TR" ? categoryEntity.Name : categoryEntity.EnglishName;
            ViewBag.Title = $"{categoryEntity.Name} - Kategori";
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPosts = posts.Count;
            ViewBag.CurrentCategory = culture == "tr-TR" ? categoryEntity.Slug : categoryEntity.EnglishSlug;
            ViewBag.NavigationPage = "Category";

            return View("Index", posts);
        }

        public ActionResult Archive(int year, int? month = null, int page = 1, int pageSize = 8)
        {
            IQueryable<Post> query = db.Posts.Include(p => p.Category);

            if (month.HasValue)
            {
                query = query.Where(p => p.CreatedAt.Year == year && p.CreatedAt.Month == month.Value);
                ViewBag.Title = $"{GetMonthName(month.Value)} {year} - Arşiv";
            }
            else
            {
                query = query.Where(p => p.CreatedAt.Year == year);
                ViewBag.Title = $"{year} - Arşiv";
            }

            var posts = query.OrderByDescending(p => p.CreatedAt).ToList();
            ViewBag.ArchiveInfo = month.HasValue ? $"{GetMonthName(month.Value)} {year}" : year.ToString();
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPosts = posts.Count;
            ViewBag.NavigationPage = "Archive"; 

            return View("Index", posts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.CurrentPage = "About";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.CurrentPage = "Contact";
            return View();
        }

        // Search functionality
        public ActionResult Search(string query, int page = 1, int pageSize = 8)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                ViewBag.SearchQuery = "";
                ViewBag.SearchResults = 0;
                ViewBag.Title = "Arama Sonuçları";
                ViewBag.NavigationPage = "Search";
                return View("Index", new List<Post>());
            }

            // Normalize the search query
            query = query.Trim();

            // Search in post titles and content
            var posts = db.Posts
                .Include(p => p.Category)
                .Where(p => p.Title.Contains(query) || p.Content.Contains(query))
                .OrderByDescending(p => p.CreatedAt)
                .ToList();

            ViewBag.SearchQuery = query;
            ViewBag.SearchResults = posts.Count;
            ViewBag.Title = $"'{query}' için Arama Sonuçları";
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPosts = posts.Count;
            ViewBag.NavigationPage = "Search";

            return View("Index", posts);
        }

        // Helper method to generate URL-friendly slugs
        private string GenerateSlug(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "genel";

            // Convert to lowercase and replace Turkish characters
            text = text.ToLower()
                .Replace("ç", "c")
                .Replace("ğ", "g")
                .Replace("ı", "i")
                .Replace("ö", "o")
                .Replace("ş", "s")
                .Replace("ü", "u");

            // Remove special characters and replace spaces with hyphens
            text = System.Text.RegularExpressions.Regex.Replace(text, @"[^a-z0-9\s-]", "");
            text = System.Text.RegularExpressions.Regex.Replace(text, @"\s+", "-");
            text = text.Trim('-');

            return string.IsNullOrEmpty(text) ? "genel" : text;
        }

        // Helper method to get Turkish month names
        private string GetMonthName(int month)
        {
            string[] monthNames = {
                "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran",
                "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"
            };

            return month >= 1 && month <= 12 ? monthNames[month - 1] : "";
        }

        // Language switching
        public ActionResult ChangeLanguage(string culture, string returnUrl)
        {
            if (!string.IsNullOrEmpty(culture))
            {
                Session["Culture"] = culture;
            }

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                // Check if the return URL is a category page and update the category slug based on new culture
                var uri = new Uri(Request.Url, returnUrl);
                var segments = uri.Segments;
                
                // Check if this is a category URL pattern (/Home/Category/{categorySlug})
                if (segments.Length >= 4 && segments[1].Equals("Home/", StringComparison.OrdinalIgnoreCase) && 
                    segments[2].Equals("Category/", StringComparison.OrdinalIgnoreCase))
                {
                    var currentCategorySlug = segments[3].TrimEnd('/');
                    
                    // Find the category by either Turkish or English slug
                    var categoryEntity = db.Categories.FirstOrDefault(c => 
                        c.Slug.ToLower() == currentCategorySlug.ToLower() || 
                        c.EnglishSlug.ToLower() == currentCategorySlug.ToLower());
                    
                    if (categoryEntity != null)
                    {
                        // Get the appropriate slug for the new culture
                        var newCategorySlug = culture == "tr-TR" ? categoryEntity.Slug : categoryEntity.EnglishSlug;
                        
                        // Redirect to the category page with the new slug
                        return RedirectToAction("Category", "Home", new { category = newCategorySlug });
                    }
                }
                
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index");
        }
    }
}