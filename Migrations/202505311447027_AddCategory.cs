namespace BlogApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Slug = c.String(nullable: false, maxLength: 200),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Slug, unique: true);
            
            AddColumn("dbo.Posts", "CategoryId", c => c.Int());
            AlterColumn("dbo.Posts", "UpdatedAt", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Posts", "CategoryId");
            AddForeignKey("dbo.Posts", "CategoryId", "dbo.Categories", "Id");
            DropColumn("dbo.Posts", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Category", c => c.String(maxLength: 100));
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "Slug" });
            AlterColumn("dbo.Posts", "UpdatedAt", c => c.DateTime());
            DropColumn("dbo.Posts", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
