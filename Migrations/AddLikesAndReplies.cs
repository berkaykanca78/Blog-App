namespace BlogApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLikesAndReplies : DbMigration
    {
        public override void Up()
        {
            // Posts tablosuna LikeCount kolonu ekle
            AddColumn("dbo.Posts", "LikeCount", c => c.Int(nullable: false, defaultValue: 0));
            
            // Comments tablosuna LikeCount ve ParentCommentId kolonları ekle
            AddColumn("dbo.Comments", "LikeCount", c => c.Int(nullable: false, defaultValue: 0));
            AddColumn("dbo.Comments", "ParentCommentId", c => c.Int());
            
            // ParentCommentId için foreign key ekle
            CreateIndex("dbo.Comments", "ParentCommentId");
            AddForeignKey("dbo.Comments", "ParentCommentId", "dbo.Comments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ParentCommentId", "dbo.Comments");
            DropIndex("dbo.Comments", new[] { "ParentCommentId" });
            DropColumn("dbo.Comments", "ParentCommentId");
            DropColumn("dbo.Comments", "LikeCount");
            DropColumn("dbo.Posts", "LikeCount");
        }
    }
} 