namespace BlogApp.Migrations
{
    using BlogApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlogApp.Models.ApplicationDbContext context)
        {
            // Sample Categories
            context.Categories.AddOrUpdate(c => c.Name,
                new Category { Name = "Teknoloji", Slug = "teknoloji", Description = "Teknoloji haberleri" },
                new Category { Name = "Yazılım", Slug = "yazilim", Description = "Yazılım geliştirme" },
                new Category { Name = "Web", Slug = "web", Description = "Web teknolojileri" }
            );

            context.SaveChanges();

            // Sample Posts
            context.Posts.AddOrUpdate(p => p.Title,
                new Post 
                { 
                    Title = "ASP.NET MVC ile Blog Uygulaması", 
                    Content = "<p>Bu yazıda ASP.NET MVC kullanarak nasıl blog uygulaması geliştirebileceğinizi öğreneceksiniz.</p>",
                    Summary = "ASP.NET MVC blog uygulaması geliştirme rehberi",
                    Author = "Berkay Kanca",
                    CategoryId = context.Categories.First(c => c.Slug == "yazilim").Id,
                    Tags = "asp.net,mvc,web",
                    Image = "https://images.unsplash.com/photo-1498050108023-c5249f4df085?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Post 
                { 
                    Title = "Yapay Zeka ve Gelecek", 
                    Content = "<p>Yapay zeka teknolojilerinin geleceğe etkilerini inceliyoruz.</p>",
                    Summary = "Yapay zeka teknolojilerinin gelecekteki etkileri",
                    Author = "Berkay Kanca",
                    CategoryId = context.Categories.First(c => c.Slug == "teknoloji").Id,
                    Tags = "ai,artificial intelligence,gelecek",
                    Image = "https://images.unsplash.com/photo-1485827404703-89b55fcc595e?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                },
                new Post 
                { 
                    Title = "Modern Web Geliştirme", 
                    Content = "<p>Modern web geliştirme araçları ve teknikleri hakkında bilgi edinin.</p>",
                    Summary = "Modern web geliştirme araçları ve teknikleri",
                    Author = "Berkay Kanca",
                    CategoryId = context.Categories.First(c => c.Slug == "web").Id,
                    Tags = "html,css,javascript,frontend",
                    Image = "https://images.unsplash.com/photo-1461749280684-dccba630e2f6?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80"
                }
            );

            context.SaveChanges();
        }
    }
}
