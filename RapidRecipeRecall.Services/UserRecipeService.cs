using RapidRecipeRecall.Data;
using RapidRecipeRecall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidRecipeRecall.Services
{
    public class UserRecipeService
    {
        private readonly Guid _userId;

        public UserRecipeService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateUserRecipe(UserRecipeCreate model)
        {
            var entity =
                new UserRecipe()
                {
                    RecipeId = model.RecipeId,
                    UserId = _userId.ToString(),
                    AddToFavorites = model.AddToFavorites,
                    Notes = model.Notes,

                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.UserRecipes.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
        }


        //public IEnumerable<UserRecipeListItem> GetAllUserRecipes()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //                .UserRecipes
        //                .Where(e => e.UserId == )
        //                .Select(
        //                    e =>
        //                        new UserRecipeListItem
        //                        {
        //                            Id = e.Id,
        //                            RecipeId = e.RecipeId,
        //                            UserId = e.UserId,
        //                            Notes = e.Notes,
        //                        }
        //                );

        //        return query.ToArray();
        //    }
        //}

        //public UserRecipeDetail GetUserRecipeById(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .UserRecipes
        //                .Single(e => e.UserRecipeId == id);
        //        return
        //            new UserRecipeDetail
        //            {
        //                Id = entity.Id,
        //                RecipeId = entity.RecipeId,
        //                UserId = entity.UserId,
        //                Notes = entity.Notes,

        //            };
        //    }
        //}

        //public bool UpdateUserRecipe(UserRecipeEdit model, int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .UserRecipes
        //                .Single(e => e.RecipeId == id);

        //        entity.Id = model.Id;
        //        entity.RecipeId = model.RecipeId;
        //        entity.UserId = model.UserId;
        //        entity.Notes = model.Notes;

        //        return ctx.SaveChanges() == 1;
        //    }
        //}

        //public bool DeleteUserRecipe(int recipeId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .UserRecipes
        //                .Single(e => e.RecipeId == recipeId);

        //        ctx.UserRecipes.Remove(entity);

        //        return ctx.SaveChanges() == 1;
        //    }
        //}

    }
}
