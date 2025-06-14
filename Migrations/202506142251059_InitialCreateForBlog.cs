namespace BlogApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateForBlog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Blog.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        EnglishName = c.String(maxLength: 100),
                        Slug = c.String(nullable: false, maxLength: 200),
                        EnglishSlug = c.String(maxLength: 200),
                        Description = c.String(),
                        EnglishDescription = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Slug, unique: true);
            
            CreateTable(
                "Blog.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        EnglishTitle = c.String(maxLength: 200),
                        Content = c.String(nullable: false),
                        EnglishContent = c.String(),
                        Summary = c.String(),
                        EnglishSummary = c.String(),
                        Image = c.String(),
                        Author = c.String(maxLength: 100),
                        CommentCount = c.Int(nullable: false),
                        LikeCount = c.Int(nullable: false),
                        Tags = c.String(maxLength: 500),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Blog.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "Blog.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 500),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        LikeCount = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        PostId = c.Int(),
                        ParentCommentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Blog.Comments", t => t.ParentCommentId)
                .ForeignKey("Blog.Posts", t => t.PostId)
                .Index(t => t.PostId)
                .Index(t => t.ParentCommentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Blog.Comments", "PostId", "Blog.Posts");
            DropForeignKey("Blog.Comments", "ParentCommentId", "Blog.Comments");
            DropForeignKey("Blog.Posts", "CategoryId", "Blog.Categories");
            DropIndex("Blog.Comments", new[] { "ParentCommentId" });
            DropIndex("Blog.Comments", new[] { "PostId" });
            DropIndex("Blog.Posts", new[] { "CategoryId" });
            DropIndex("Blog.Categories", new[] { "Slug" });
            DropTable("Blog.Comments");
            DropTable("Blog.Posts");
            DropTable("Blog.Categories");
        }
    }
}
