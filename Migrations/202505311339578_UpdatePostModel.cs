namespace BlogApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePostModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Summary", c => c.String());
            AddColumn("dbo.Posts", "Category", c => c.String(maxLength: 100));
            AddColumn("dbo.Posts", "Author", c => c.String(maxLength: 100));
            AddColumn("dbo.Posts", "CommentCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "CommentCount");
            DropColumn("dbo.Posts", "Author");
            DropColumn("dbo.Posts", "Category");
            DropColumn("dbo.Posts", "Summary");
        }
    }
}
