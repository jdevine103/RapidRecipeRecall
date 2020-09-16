namespace RapidRecipeRecall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PleaseWork : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "UserRecipeId", "dbo.UserRecipe");
            DropIndex("dbo.Comment", new[] { "UserRecipeId" });
            AddColumn("dbo.Comment", "RecipeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comment", "RecipeId");
            AddForeignKey("dbo.Comment", "RecipeId", "dbo.Recipe", "RecipeId", cascadeDelete: true);
            DropColumn("dbo.Comment", "UserRecipeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "UserRecipeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Comment", "RecipeId", "dbo.Recipe");
            DropIndex("dbo.Comment", new[] { "RecipeId" });
            DropColumn("dbo.Comment", "RecipeId");
            CreateIndex("dbo.Comment", "UserRecipeId");
            AddForeignKey("dbo.Comment", "UserRecipeId", "dbo.UserRecipe", "Id", cascadeDelete: true);
        }
    }
}
