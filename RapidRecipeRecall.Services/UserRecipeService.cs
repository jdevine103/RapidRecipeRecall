using RapidRecipeRecall.Data;
using RapidRecipeRecall.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
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
                    //Notes = model.Notes,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.UserRecipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool CreateUserRecipeAuto(Recipe entity)
        {
            var userRecipe =
            new UserRecipe
            {
                RecipeId = entity.RecipeId,
                UserId = entity.UserId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.UserRecipes.Add(userRecipe);
                return ctx.SaveChanges() == 1;
            }
        }


        //public IEnumerable<UserRecipeListItem> GetMyRecipesByUserId()
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

        public IEnumerable<UserRecipeListItem> GetMyRecipesByUserId(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .FirstOrDefault(e => e.Id.ToString() == id);
                var userRecipe = entity.MyRecipes.Select(
                   e => new UserRecipeListItem
                   {
                       Id = e.Id,
                       RecipeId = e.RecipeId,
                       Notes = e.Notes,
                       UserId = e.UserId,
                   }
                   );
                return userRecipe.ToArray();
            }
        }

        public IEnumerable<UserRecipeListItem> GetMyFavoritesByUserId(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .FirstOrDefault(e => e.Id.ToString() == id);
                var userRecipe = entity.MyFavorites.Select(
                   e => new UserRecipeListItem
                   {
                       Id = e.Id,
                       RecipeId = e.RecipeId,
                       Notes = e.Notes,
                       UserId = e.UserId,
                   }
                   );
                return userRecipe.ToArray();
            }
        }
        public bool UpdateUserRecipeAddNote(UserRecipeAddNote model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserRecipes
                        .Single(e => e.Id == id && e.User.Id == _userId.ToString());

                var noteService = CreateNoteService();
                noteService.CreateNote(model);

                //Note note =
                //    new Note()
                //    {
                //        Text = model.Text
                //    };

     
                return ctx.SaveChanges() == 1;

                //entity.Notes.Add(note);

                //return worked;

            }
        }

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
        private NoteService CreateNoteService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            NoteService noteService = new NoteService(_userId);
            return noteService;
        }
    }
}
