namespace BlogApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnglishCultureForTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "EnglishName", c => c.String(maxLength: 100));
            AddColumn("dbo.Categories", "EnglishDescription", c => c.String());
            AddColumn("dbo.Posts", "EnglishTitle", c => c.String(maxLength: 200));
            AddColumn("dbo.Posts", "EnglishContent", c => c.String());
            AddColumn("dbo.Posts", "EnglishSummary", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "EnglishSummary");
            DropColumn("dbo.Posts", "EnglishContent");
            DropColumn("dbo.Posts", "EnglishTitle");
            DropColumn("dbo.Categories", "EnglishDescription");
            DropColumn("dbo.Categories", "EnglishName");
        }
    }
}
