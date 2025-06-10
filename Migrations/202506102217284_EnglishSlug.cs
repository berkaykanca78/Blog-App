namespace BlogApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnglishSlug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "EnglishSlug", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "EnglishSlug");
        }
    }
}
