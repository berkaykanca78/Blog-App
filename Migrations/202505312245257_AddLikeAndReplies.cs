namespace BlogApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLikeAndReplies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "LikeCount", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "LikeCount", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "ParentCommentId", c => c.Int());
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
