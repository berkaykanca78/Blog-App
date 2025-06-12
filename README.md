# 📝 BlogApp - ASP.NET MVC Blog Uygulaması

## 🌟 Proje Açıklaması

BlogApp, modern bir blog platformu olan ASP.NET MVC tabanlı bir web uygulamasıdır. Bu uygulama, kullanıcıların blog yazıları oluşturmasına, kategorilere ayırmasına, yorum yapmasına ve etkileşimde bulunmasına olanak tanır. Responsive tasarım ve kullanıcı dostu arayüzü ile modern blog ihtiyaçlarını karşılar.

## ✨ Özellikler

### 📖 Blog Yazı Yönetimi
- **Yazı Oluşturma**: Zengin içerikli blog yazıları oluşturma
- **Yazı Düzenleme**: Mevcut yazıları güncelleme ve düzenleme
- **Yazı Silme**: İstenmeyen yazıları kaldırma
- **Özet Görünümü**: Yazılar için özet ve tam içerik desteği
- **Görsel Desteği**: Blog yazılarına resim ekleme imkânı

### 🏷️ Kategori Sistemi
- **Kategori Oluşturma**: Blog yazıları için kategoriler tanımlama
- **Kategori Yönetimi**: Kategorileri düzenleme ve silme
- **Kategori Slug'ları**: SEO dostu URL yapısı
- **Kategoriye Göre Filtreleme**: Yazıları kategorilere göre görüntüleme

### 💬 Yorum Sistemi
- **Yorum Yapma**: Blog yazılarına yorum ekleme
- **Yorum Yanıtlama**: Yorumlara cevap verme (threaded comments)
- **Yorum Beğenme**: Yorumları beğenme sistemi
- **Yorum Moderasyonu**: Yorum yönetimi ve düzenleme

### 👍 Sosyal Etkileşim
- **Yazı Beğenme**: Blog yazılarını beğenme sistemi
- **Yorum Sayacı**: Her yazının yorum sayısını görüntüleme
- **Beğeni Sayacı**: Yazı ve yorum beğeni istatistikleri

### 🏷️ Etiket Sistemi
- **Tag Desteği**: Blog yazılarına etiket ekleme
- **Tag Arama**: Etiketlere göre içerik bulma
- **Tag Yönetimi**: Etiket düzenleme ve organizasyon

## 🛠️ Kullanılan Teknolojiler

### Backend Teknolojileri
- **ASP.NET MVC 5.2.9** - Web framework
- **.NET Framework 4.8** - Uygulama framework'ü
- **Entity Framework 6.5.1** - ORM (Object-Relational Mapping)
- **C#** - Programlama dili
- **Code First Migrations** - Veritabanı şema yönetimi

### Frontend Teknolojileri
- **Bootstrap 5.2.3** - CSS framework ve responsive tasarım
- **jQuery 3.7.0** - JavaScript kütüphanesi
- **HTML5** - Markup dili
- **CSS3** - Stil tanımlamaları
- **Razor View Engine** - Server-side rendering

### Veritabanı ve ORM
- **SQL Server** - Veritabanı yönetim sistemi
- **Entity Framework Code First** - Veritabanı modelleme
- **LINQ** - Veri sorgulama

### JavaScript Kütüphaneleri
- **jQuery Validation 1.19.5** - Form doğrulama
- **jQuery Unobtrusive Validation 3.2.11** - Örtük doğrulama
- **Modernizr 2.8.3** - Browser özellik tespiti

### Yardımcı Teknolojiler
- **Newtonsoft.Json 13.0.3** - JSON işlemleri
- **Web Optimization (Bundling & Minification)** - Performans optimizasyonu
- **Antlr 3.5.0.2** - Parser jeneratörü
- **WebGrease** - Web asset optimizasyonu

### Development Tools
- **Visual Studio** - IDE
- **IIS Express** - Development server
- **NuGet Package Manager** - Paket yönetimi
- **.NET Compiler Platform** - Kod derleyici

## 📁 Proje Yapısı

```
BlogApp/
├── 📁 Controllers/          # MVC Controller'ları
│   ├── HomeController.cs    # Ana sayfa kontrolcüsü
│   └── BaseController.cs    # Temel kontrolcü sınıfı
├── 📁 Models/              # Veri modelleri
│   ├── Post.cs             # Blog yazısı modeli
│   ├── Category.cs         # Kategori modeli
│   ├── Comment.cs          # Yorum modeli
│   └── ApplicationDbContext.cs # Entity Framework context
├── 📁 Views/               # Razor view dosyaları
├── 📁 Content/             # CSS dosyaları ve stiller
├── 📁 Scripts/             # JavaScript dosyaları
├── 📁 Migrations/          # Entity Framework migration'ları
├── 📁 App_Start/           # Uygulama başlangıç konfigürasyonları
└── 📁 App_Data/            # Uygulama verileri
```

## 🏗️ Veri Modeli

### Post (Blog Yazısı)
- **Id**: Benzersiz tanımlayıcı
- **Title**: Yazı başlığı
- **Content**: Yazı içeriği
- **Summary**: Yazı özeti
- **Image**: Görsel URL'i
- **Author**: Yazar adı
- **Tags**: Etiketler
- **CategoryId**: Kategori referansı
- **CreatedAt/UpdatedAt**: Tarih bilgileri
- **CommentCount/LikeCount**: İstatistikler

### Category (Kategori)
- **Id**: Benzersiz tanımlayıcı
- **Name**: Kategori adı
- **Slug**: SEO dostu URL
- **Description**: Kategori açıklaması
- **Posts**: İlişkili yazılar

### Comment (Yorum)
- **Id**: Benzersiz tanımlayıcı
- **Content**: Yorum içeriği
- **Name**: Yorumcu adı
- **Email**: E-posta adresi
- **PostId**: Yazı referansı
- **ParentCommentId**: Üst yorum referansı (threaded comments)
- **LikeCount**: Beğeni sayısı

## 🚀 Kurulum ve Çalıştırma

### Gereksinimler
- Visual Studio 2019 veya üzeri
- .NET Framework 4.8
- SQL Server (LocalDB destekli)
- IIS Express

### Kurulum Adımları
1. **Projeyi klonlayın**
   ```bash
   git clone [repository-url]
   cd BlogApp
   ```

2. **NuGet paketlerini geri yükleyin**
   ```bash
   nuget restore
   ```

3. **Veritabanını oluşturun**
   ```bash
   Update-Database
   ```

4. **Projeyi çalıştırın**
   - Visual Studio'da F5 tuşuna basın
   - IIS Express otomatik olarak başlayacaktır

## 🎯 Önemli Özellikler

- **Responsive Design**: Bootstrap 5 ile mobil uyumlu tasarım
- **SEO Friendly**: Temiz URL yapısı ve meta tag desteği
- **Code First**: Entity Framework Code First yaklaşımı
- **Threaded Comments**: İç içe yorum sistemi
- **AJAX Support**: Dinamik içerik yükleme
- **Validation**: Hem client hem server-side doğrulama
- **Optimized Performance**: Bundling ve minification

## 📱 Responsive Design

Uygulama Bootstrap 5 framework'ü kullanarak tüm cihazlarda (masaüstü, tablet, mobil) mükemmel görünüm sağlar.

## 🔧 Konfigürasyon

Uygulama ayarları `Web.config` dosyasında yapılandırılır:
- Veritabanı bağlantı dizesi
- Entity Framework ayarları
- Bundling ve minification konfigürasyonu

## 📄 Lisans

Bu proje açık kaynak kodlu olarak geliştirilmiştir.

## 👨‍💻 Geliştirici

**Berkay Kanca**
- GitHub: [@berkaykanca](https://github.com/berkaykanca78)
- Website: [berkaykanca.com](https://berkaykanca.com)
- Demo: [blog.berkaykanca.com](https://blog.berkaykanca.com)

## 📞 İletişim

Proje hakkında sorularınız için:
- Email: [berkaykanca@hotmail.com](mailto:berkaykanca@hotmail.com)
- LinkedIn: [Berkay Kanca](https://linkedin.com/in/berkay-kanca)

---

⭐ Bu projeyi beğendiyseniz, lütfen yıldız vermeyi unutmayın! 

**Not**: Bu uygulama, modern blog platformlarının temel ihtiyaçlarını karşılamak için tasarlanmış, genişletilebilir ve sürdürülebilir bir ASP.NET MVC uygulamasıdır. 