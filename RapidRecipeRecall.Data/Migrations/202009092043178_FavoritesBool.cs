namespace RapidRecipeRecall.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavoritesBool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRecipe", "AddToFavorites", c => c.Boolean(nullable: false));
            DropColumn("dbo.Recipe", "AddToMyList");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipe", "AddToMyList", c => c.Boolean(nullable: false));
            DropColumn("dbo.UserRecipe", "AddToFavorites");
        }
    }
}
