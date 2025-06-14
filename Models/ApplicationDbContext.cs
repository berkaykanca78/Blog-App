using System.Data.Entity;

namespace BlogApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base(GetConnectionStringName())
        {
        }

        private static string GetConnectionStringName()
        {
#if DEBUG
            return "DebugConnection"; // Web.Debug.config connection string
#else
            return "ReleaseConnection"; // Web.Release.config connection string
#endif
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Post-Category relationship
            modelBuilder.Entity<Post>()
                .HasOptional(p => p.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId)
                .WillCascadeOnDelete(false);

            // Configure Category entity
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Slug)
                .IsUnique();

            // Configure Post entity
            modelBuilder.Entity<Post>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Post>()
                .Property(p => p.Content)
                .IsRequired();

            // Configure Comment entity
            modelBuilder.Entity<Comment>()
                .Property(c => c.Content)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Comment>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Comment>()
                .Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Comment>()
                .HasOptional(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .WillCascadeOnDelete(false);

            // Configure Comment self-referencing relationship for replies
            modelBuilder.Entity<Comment>()
                .HasOptional(c => c.ParentComment)
                .WithMany(c => c.Replies)
                .HasForeignKey(c => c.ParentCommentId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
} 