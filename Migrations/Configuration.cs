using System;
using System.Data.Entity.Migrations;
using System.Linq;
using BlogApp.Contexts;
using BlogApp.Entities;

namespace BlogApp.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetHistoryContextFactory("System.Data.SqlClient", (conn, schema) => new BlogHistoryContext(conn, schema));
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // Add categories
            context.Categories.AddOrUpdate(c => c.Name,
                new Category
                {
                    Name = "Back-End",
                    Slug = "back-end",
                    Description = "Sunucu tarafı geliştirme, API'ler ve arka uç teknolojileri",
                    EnglishName = "Back-End",
                    EnglishDescription = "Server-side development, APIs, and backend technologies",
                    EnglishSlug = "back-end"
                },

                new Category
                {
                    Name = "Front-End",
                    Slug = "front-end",
                    Description = "İstemci tarafı geliştirme, UI/UX ve ön uç framework'leri",
                    EnglishName = "Front-End",
                    EnglishDescription = "Client-side development, UI/UX, and frontend frameworks",
                    EnglishSlug = "front-end"
                },

                new Category
                {
                    Name = "Veritabanı",
                    Slug = "veritabani",
                    Description = "Veritabanı yönetimi, sorgular ve optimizasyon",
                    EnglishName = "Database",
                    EnglishDescription = "Database management, queries, and optimization",
                    EnglishSlug = "database"
                },

                new Category
                {
                    Name = "Mobil",
                    Slug = "mobil",
                    Description = "Mobil uygulama geliştirme ve çapraz platform framework'leri",
                    EnglishName = "Mobile",
                    EnglishDescription = "Mobile app development and cross-platform frameworks",
                    EnglishSlug = "mobile"
                });

            context.SaveChanges();

            // Get category references for posts
            var backEndCategory = context.Categories.FirstOrDefault(c => c.Slug == "back-end");
            var frontEndCategory = context.Categories.FirstOrDefault(c => c.Slug == "front-end");
            var databaseCategory = context.Categories.FirstOrDefault(c => c.Slug == "veritabani");
            var mobileCategory = context.Categories.FirstOrDefault(c => c.Slug == "mobil");

            // Add comprehensive posts
            context.Posts.AddOrUpdate(p => p.Title,
                new Post
                {
                    Title = "ASP.NET 8 Yenilikler",
                    Summary = "ASP.NET Core 8'in getirdiği performans iyileştirmeleri, Minimal APIs ve güvenlik yenilikleri",
                    Content = @"<div class='post-content'>
    <h2>ASP.NET Core 8'in Getirdiği Yenilikler</h2>
    
    <p>ASP.NET Core 8, Microsoft'un en son web geliştirme framework'ü olarak birçok heyecan verici yenilik getiriyor. Bu yenilikler performans, güvenlik ve geliştirici deneyimi açısından önemli iyileştirmeler sunuyor.</p>

    <div class='feature-section'>
        <h3>🚀 Performans İyileştirmeleri</h3>
        <ul>
            <li><strong>Native AOT Desteği:</strong> Uygulamalar artık daha hızlı başlayıp daha az bellek kullanıyor</li>
            <li><strong>Minimal APIs Geliştirmeleri:</strong> Daha az kod ile daha güçlü API'ler</li>
            <li><strong>HTTP/3 Desteği:</strong> Daha hızlı ve güvenli web bağlantıları</li>
        </ul>
    </div>

    <div class='code-section'>
        <h3>💻 Minimal API Örneği</h3>
        <pre><code class='language-csharp'>
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet(""/products/{id}"", async (int id, IProductService service) =>
{
    var product = await service.GetByIdAsync(id);
    return product is not null ? Results.Ok(product) : Results.NotFound();
})
.WithName(""GetProduct"")
.WithOpenApi();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
        </code></pre>
    </div>

    <div class='conclusion'>
        <h3>🎯 Sonuç</h3>
        <p>ASP.NET Core 8, modern web uygulamaları geliştirmek için güçlü bir platform sunuyor. Native AOT, Minimal APIs ve gelişmiş güvenlik özellikleri ile projelerinizi daha verimli hale getirebilirsiniz.</p>
    </div>
</div>",
                    Author = "Berkay Kanca",
                    CategoryId = backEndCategory?.Id ?? 1,
                    Tags = "asp.net,core,backend,api,performance",
                    Image = "https://images.unsplash.com/photo-1498050108023-c5249f4df085?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80",
                    EnglishContent = @"<div class='post-content'>
    <h2>What's New in ASP.NET Core 8</h2>
    
    <p>ASP.NET Core 8 brings many exciting new features as Microsoft's latest web development framework. These innovations offer significant improvements in performance, security, and developer experience.</p>

    <div class='feature-section'>
        <h3>🚀 Performance Improvements</h3>
        <ul>
            <li><strong>Native AOT Support:</strong> Applications now start faster and use less memory</li>
            <li><strong>Minimal APIs Enhancements:</strong> More powerful APIs with less code</li>
            <li><strong>HTTP/3 Support:</strong> Faster and more secure web connections</li>
        </ul>
    </div>

    <div class='code-section'>
        <h3>💻 Minimal API Example</h3>
        <pre><code class='language-csharp'>
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet(""/products/{id}"", async (int id, IProductService service) =>
{
    var product = await service.GetByIdAsync(id);
    return product is not null ? Results.Ok(product) : Results.NotFound();
})
.WithName(""GetProduct"")
.WithOpenApi();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
        </code></pre>
    </div>

    <div class='conclusion'>
        <h3>🎯 Conclusion</h3>
        <p>ASP.NET Core 8 provides a powerful platform for developing modern web applications. With Native AOT, Minimal APIs, and advanced security features, you can make your projects more efficient.</p>
    </div>
</div>",
                    EnglishSummary = "Performance improvements, Minimal APIs, and security innovations in ASP.NET Core 8",
                    EnglishTitle = "What's New in ASP.NET 8",
                    CreatedAt = DateTime.Now.AddDays(-30),
                    UpdatedAt = DateTime.Now.AddDays(-30)
                },
                new Post
                {
                    Title = "Angular 18 Yenilikler",
                    Summary = "Angular 18'de signal tabanlı değişiklik algılama, standalone bileşenler ve performans iyileştirmeleri",
                    Content = @"<div class='post-content'>
    <h2>Angular 18'in Getirdiği Devrimsel Yenilikler</h2>
    
    <p>Angular 18, Google'ın popüler frontend framework'ünde büyük yenilikler getiriyor. Signal tabanlı değişiklik algılama, standalone bileşenler ve performans iyileştirmeleri ile modern web uygulamaları geliştirmek artık daha kolay.</p>

    <div class='feature-section'>
        <h3>⚡ Signal Tabanlı Değişiklik Algılama</h3>
        <p>Angular 18'in en büyük yeniliği signal tabanlı reaktif sistem. Bu sistem, uygulamaların performansını önemli ölçüde artırıyor ve Zone.js bağımlılığını azaltıyor.</p>
        
        <div class='code-section'>
            <h4>💻 Signal Kullanımı</h4>
            <pre><code class='language-typescript'>
import { Component, signal, computed } from '@angular/core';

@Component({
  selector: 'app-counter',
  template: \`
    <div class=""counter-container"">
      <h2>Counter: {{ count() }}</h2>
      <p>Double: {{ doubleCount() }}</p>
      <button (click)=""increment()"">Increment</button>
      <button (click)=""decrement()"">Decrement</button>
    </div>
  \`,
  standalone: true
})
export class CounterComponent {
  count = signal(0);
  doubleCount = computed(() => this.count() * 2);

  increment() {
    this.count.update(value => value + 1);
  }

  decrement() {
    this.count.update(value => value - 1);
  }
}
            </code></pre>
        </div>
    </div>

    <div class='conclusion'>
        <h3>🎯 Sonuç</h3>
        <p>Angular 18, modern web geliştirme için güçlü araçlar sunuyor. Signal tabanlı reaktif sistem, standalone bileşenler ve gelişmiş SSR özellikleri ile daha performanslı ve sürdürülebilir uygulamalar geliştirebilirsiniz.</p>
    </div>
</div>",
                    Author = "Berkay Kanca",
                    CategoryId = frontEndCategory?.Id ?? 2,
                    Tags = "angular,frontend,javascript,typescript,signals",
                    Image = "https://images.unsplash.com/photo-1461749280684-dccba630e2f6?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80",
                    EnglishContent = @"<div class='post-content'>
    <h2>Revolutionary Features in Angular 18</h2>
    
    <p>Angular 18 brings major innovations to Google's popular frontend framework. With signal-based change detection, standalone components, and performance improvements, developing modern web applications is now easier than ever.</p>

    <div class='feature-section'>
        <h3>⚡ Signal-Based Change Detection</h3>
        <p>Angular 18's biggest innovation is the signal-based reactive system. This system significantly improves application performance and reduces Zone.js dependency.</p>
        
        <div class='code-section'>
            <h4>💻 Signal Usage</h4>
            <pre><code class='language-typescript'>
import { Component, signal, computed } from '@angular/core';

@Component({
  selector: 'app-counter',
  template: \`
    <div class=""counter-container"">
      <h2>Counter: {{ count() }}</h2>
      <p>Double: {{ doubleCount() }}</p>
      <button (click)=""increment()"">Increment</button>
      <button (click)=""decrement()"">Decrement</button>
    </div>
  \`,
  standalone: true
})
export class CounterComponent {
  count = signal(0);
  doubleCount = computed(() => this.count() * 2);

  increment() {
    this.count.update(value => value + 1);
  }

  decrement() {
    this.count.update(value => value - 1);
  }
}
            </code></pre>
        </div>
    </div>

    <div class='conclusion'>
        <h3>🎯 Conclusion</h3>
        <p>Angular 18 provides powerful tools for modern web development. With signal-based reactive systems, standalone components, and enhanced SSR features, you can develop more performant and maintainable applications.</p>
    </div>
</div>",
                    EnglishSummary = "Signal-based change detection, standalone components, and performance improvements in Angular 18",
                    EnglishTitle = "Revolutionary Features in Angular 18",
                    CreatedAt = DateTime.Now.AddDays(-25),
                    UpdatedAt = DateTime.Now.AddDays(-25)
                },
                new Post
                {
                    Title = "PostgreSQL Sık Kullanılan Komutlar",
                    Summary = "PostgreSQL'de en çok kullanılan CRUD işlemleri, JOIN'ler ve performans optimizasyon komutları",
                    Content = @"<div class='post-content'>
    <h2>PostgreSQL'de En Sık Kullanılan Komutlar</h2>
    
    <p>PostgreSQL, güçlü ve açık kaynaklı bir ilişkisel veritabanı yönetim sistemidir. Bu rehberde, PostgreSQL ile çalışırken en çok ihtiyaç duyacağınız komutları öğreneceksiniz.</p>

    <div class='code-section'>
        <h3>🔌 Bağlantı Komutları</h3>
        <pre><code class='language-sql'>
-- PostgreSQL'e bağlanma
psql -U username -h localhost -p 5432 database_name

-- Veritabanları listesi
\l

-- Veritabanına geçiş
\c database_name

-- Tabloları listeleme
\dt

-- Çıkış
\q
        </code></pre>
    </div>

    <div class='code-section'>
        <h3>📊 Temel CRUD İşlemleri</h3>
        <pre><code class='language-sql'>
-- Veri Ekleme
INSERT INTO users (name, email, age) 
VALUES ('Ahmet Yılmaz', 'ahmet@example.com', 25);

-- Veri Sorgulama
SELECT * FROM users WHERE age > 25;

-- Veri Güncelleme
UPDATE users SET age = 26 WHERE name = 'Ahmet Yılmaz';

-- Veri Silme
DELETE FROM users WHERE age < 18;
        </code></pre>
    </div>

    <div class='conclusion'>
        <h3>🎯 Sonuç</h3>
        <p>Bu komutlar PostgreSQL ile verimli çalışmanız için temel araçlardır. Düzenli pratik yaparak bu komutları ustaca kullanabilir ve veritabanı yönetiminde uzmanlaşabilirsiniz.</p>
    </div>
</div>",
                    Author = "Berkay Kanca",
                    CategoryId = databaseCategory?.Id ?? 3,
                    Tags = "postgresql,database,sql,commands,crud",
                    Image = "https://images.unsplash.com/photo-1544383835-bda2bc66a55d?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80",
                    EnglishContent = @"<div class='post-content'>
    <h2>Most Commonly Used PostgreSQL Commands</h2>
    
    <p>PostgreSQL is a powerful and open-source relational database management system. In this guide, you'll learn the commands you'll need most when working with PostgreSQL.</p>

    <div class='code-section'>
        <h3>🔌 Connection Commands</h3>
        <pre><code class='language-sql'>
-- Connect to PostgreSQL
psql -U username -h localhost -p 5432 database_name

-- List databases
\l

-- Switch to database
\c database_name

-- List tables
\dt

-- Exit
\q
        </code></pre>
    </div>

    <div class='code-section'>
        <h3>📊 Basic CRUD Operations</h3>
        <pre><code class='language-sql'>
-- Insert Data
INSERT INTO users (name, email, age) 
VALUES ('John Doe', 'john@example.com', 25);

-- Query Data
SELECT * FROM users WHERE age > 25;

-- Update Data
UPDATE users SET age = 26 WHERE name = 'John Doe';

-- Delete Data
DELETE FROM users WHERE age < 18;
        </code></pre>
    </div>

    <div class='conclusion'>
        <h3>🎯 Conclusion</h3>
        <p>These commands are essential tools for working efficiently with PostgreSQL. With regular practice, you can master these commands and become an expert in database management.</p>
    </div>
</div>",
                    EnglishSummary = "Most commonly used CRUD operations, JOINs and performance optimization commands in PostgreSQL",
                    EnglishTitle = "Most Commonly Used PostgreSQL Commands",
                    CreatedAt = DateTime.Now.AddDays(-20),
                    UpdatedAt = DateTime.Now.AddDays(-20)
                },
                new Post
                {
                    Title = ".NET MAUI Nedir",
                    Summary = ".NET MAUI ile çoklu platform uygulama geliştirme, XAML kullanımı ve native performans avantajları",
                    Content = @"<div class='post-content'>
    <h2>.NET MAUI: Çoklu Platform Uygulama Geliştirme</h2>
    
    <p>.NET Multi-platform App UI (.NET MAUI), Microsoft'un C# ve XAML kullanarak Android, iOS, macOS ve Windows için yerel uygulamalar geliştirmenizi sağlayan cross-platform framework'üdür.</p>

    <div class='feature-section'>
        <h3>🎯 .NET MAUI Nedir?</h3>
        <p>.NET MAUI, Xamarin.Forms'un evrimi olarak geliştirilmiş, tek bir kodla birden fazla platforma uygulama geliştirmenizi sağlayan açık kaynaklı bir framework'tür.</p>
        
        <ul>
            <li><strong>Tek Kod Tabanı:</strong> Tüm platformlar için tek proje</li>
            <li><strong>Yerel Performans:</strong> Her platforma native derleme</li>
            <li><strong>Zengin UI:</strong> Platform özel UI elementleri</li>
            <li><strong>Modern Araçlar:</strong> Visual Studio entegrasyonu</li>
        </ul>
    </div>

    <div class='code-section'>
        <h3>💻 Temel XAML Örneği</h3>
        <pre><code class='language-xml'>
<?xml version=""1.0"" encoding=""utf-8"" ?>
<ContentPage x:Class=""MyApp.MainPage""
             xmlns=""http://schemas.microsoft.com/dotnet/2021/maui""
             xmlns:x=""http://schemas.microsoft.com/winfx/2009/xaml"">
    
    <ScrollView>
        <VerticalStackLayout Spacing=""25"" Padding=""30,0"">
            
            <Image Source=""dotnet_bot.png""
                   HeightRequest=""200""
                   HorizontalOptions=""Center"" />
            
            <Label x:Name=""CounterLabel""
                   Text=""Merhaba .NET MAUI!""
                   FontSize=""18""
                   HorizontalOptions=""Center"" />
            
            <Button x:Name=""CounterBtn""
                    Text=""Tıkla""
                    Clicked=""OnCounterClicked""
                    HorizontalOptions=""Center"" />
            
        </VerticalStackLayout>
    </ScrollView>
    
</ContentPage>
        </code></pre>
    </div>

    <div class='conclusion'>
        <h3>🎯 Sonuç</h3>
        <p>.NET MAUI, özellikle .NET ekosisteminde çalışan geliştiriciler için güçlü bir cross-platform çözümüdür. Tek kod tabanı ile birden fazla platforma uygulama geliştirme imkanı sunan bu framework, native performans ve zengin UI özellikleri ile projelerinizi hızla hayata geçirmenizi sağlar.</p>
    </div>
</div>",
                    Author = "Berkay Kanca",
                    CategoryId = mobileCategory?.Id ?? 4,
                    Tags = "dotnet,maui,mobile,xaml,cross-platform",
                    Image = "https://images.unsplash.com/photo-1512941937669-90a1b58e7e9c?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=80",
                    EnglishContent = @"<div class='post-content'>
    <h2>.NET MAUI: Multi-platform Application Development</h2>
    
    <p>.NET Multi-platform App UI (.NET MAUI) is Microsoft's cross-platform framework that enables you to create native applications for Android, iOS, macOS, and Windows using C# and XAML.</p>

    <div class='feature-section'>
        <h3>🎯 What is .NET MAUI?</h3>
        <p>.NET MAUI is an open-source framework developed as the evolution of Xamarin.Forms, allowing you to develop applications for multiple platforms with a single codebase.</p>
        
        <ul>
            <li><strong>Single Codebase:</strong> One project for all platforms</li>
            <li><strong>Native Performance:</strong> Native compilation for each platform</li>
            <li><strong>Rich UI:</strong> Platform-specific UI elements</li>
            <li><strong>Modern Tools:</strong> Visual Studio integration</li>
        </ul>
    </div>

    <div class='code-section'>
        <h3>💻 Basic XAML Example</h3>
        <pre><code class='language-xml'>
<?xml version=""1.0"" encoding=""utf-8"" ?>
<ContentPage x:Class=""MyApp.MainPage""
             xmlns=""http://schemas.microsoft.com/dotnet/2021/maui""
             xmlns:x=""http://schemas.microsoft.com/winfx/2009/xaml"">
    
    <ScrollView>
        <VerticalStackLayout Spacing=""25"" Padding=""30,0"">
            
            <Image Source=""dotnet_bot.png""
                   HeightRequest=""200""
                   HorizontalOptions=""Center"" />
            
            <Label x:Name=""CounterLabel""
                   Text=""Hello .NET MAUI!""
                   FontSize=""18""
                   HorizontalOptions=""Center"" />
            
            <Button x:Name=""CounterBtn""
                    Text=""Click me""
                    Clicked=""OnCounterClicked""
                    HorizontalOptions=""Center"" />
            
        </VerticalStackLayout>
    </ScrollView>
    
</ContentPage>
        </code></pre>
    </div>

    <div class='conclusion'>
        <h3>🎯 Conclusion</h3>
        <p>.NET MAUI is a powerful cross-platform solution, especially for developers working in the .NET ecosystem. This framework, which offers the opportunity to develop applications for multiple platforms with a single codebase, enables you to quickly bring your projects to life with native performance and rich UI features.</p>
    </div>
</div>",
                    EnglishSummary = "Multi-platform app development with .NET MAUI, XAML usage and native performance advantages",
                    EnglishTitle = "What is .NET MAUI",
                    CreatedAt = DateTime.Now.AddDays(-15),
                    UpdatedAt = DateTime.Now.AddDays(-15)
                }
            );

            context.SaveChanges();
        }
    }
}
