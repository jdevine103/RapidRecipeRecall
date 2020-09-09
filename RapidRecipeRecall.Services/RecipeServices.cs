using RapidRecipeRecall.Data;
using RapidRecipeRecall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidRecipeRecall.Services
{
    public class RecipeService
    {
        private readonly Guid _userId;

        public RecipeService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateRecipe(RecipeCreate model) 
        {
            var entity =
                new Recipe()
                {
                    //EnteredBy = model.EnteredBy,
                    RecipeName = model.RecipeName,
                    RecipeAuthor = model.RecipeAuthor,
                    IsPublic = model.IsPublic,
                    AddToMyList = model.AddToMyList,
                    Ingredients = model.Ingredients,
                    Instructions = model.Instructions,
                    Category = model.Category,
                    UserId = _userId.ToString()
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RecipeListItem> GetAllRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes.Where(e => e.IsPublic).Select(
                            e =>
                                new RecipeListItem
                                {
                                    RecipeId = e.RecipeId,
                                    RecipeName = e.RecipeName,
                                    RecipeAuthor = e.RecipeAuthor,
                                    Ingredients = e.Ingredients,
                                    Instructions = e.Instructions,
                                    Category = e.Category,

                                }
                        );

                return query.ToArray();
            }
        }

        public RecipeDetail GetRecipeByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeName == name && e.IsPublic == true); 
                return
                    new RecipeDetail
                    {
                        RecipeName = entity.RecipeName,
                        RecipeAuthor = entity.RecipeAuthor,
                        Ingredients = entity.Ingredients,
                        Instructions = entity.Instructions,
                        Category = entity.Category,

                    };
            }
        }

        public RecipeDetail GetRecipeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeId == id);
                return
                    new RecipeDetail
                    {
                        EnteredBy = entity.EnteredBy,
                        RecipeId = entity.RecipeId,
                        RecipeName = entity.RecipeName,
                        RecipeAuthor = entity.RecipeAuthor,
                        Ingredients = entity.Ingredients,
                        Instructions = entity.Instructions,
                        Category = entity.Category,

                    };
            }
        }

        public bool UpdateRecipe(RecipeEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeId == id); 
                

                entity.RecipeName = model.RecipeName;
                entity.RecipeAuthor = model.RecipeAuthor;
                entity.Ingredients = model.Ingredients; 
                entity.Instructions = model.Instructions; 
                entity.Category = model.Category;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRecipe(int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeId == recipeId);

                ctx.Recipes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
