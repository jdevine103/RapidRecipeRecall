namespace RapidRecipeRecall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKinNote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Note", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Note", "UserId");
            AddForeignKey("dbo.Note", "UserId", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Note", "UserId", "dbo.ApplicationUser");
            DropIndex("dbo.Note", new[] { "UserId" });
            DropColumn("dbo.Note", "UserId");
        }
    }
}
