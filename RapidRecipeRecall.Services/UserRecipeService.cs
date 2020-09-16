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

        public IEnumerable<NoteListItem> GetNotesByUserRecipeId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                  var entity =
                    ctx
                        .UserRecipes
                        //This is the difference between comment and note 
                        .FirstOrDefault(e => e.Id == id && e.User.Id.ToString() == _userId.ToString());

                var notes = entity.Notes.Select(
                   e => new NoteListItem
                   {
                      NoteId = e.NoteId,
                      Text = e.Text,
                      UserRecipeId = e.UserRecipeId
                   }
                   );
                return notes.ToList();
            }
        }

        public IEnumerable<UserRecipeListItem> GetMyRecipesByUserId(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =   
                    ctx
                        .Users
                        //                  From .Users.Id - passed int - .Users.Id       From logged in user
                        .FirstOrDefault(e => e.Id.ToString() == id && e.Id.ToString() == _userId.ToString());
                var userRecipe = entity.MyRecipes.Select(
                   e => new UserRecipeListItem
                   {
                       Id = e.Id,
                       RecipeId = e.RecipeId,
                       Notes = GetNotesByUserRecipeId(e.Id),
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
                        .FirstOrDefault(e => e.Id.ToString() == id && e.Id.ToString() == _userId.ToString());
                var userRecipe = entity.MyFavorites.Select(
                   e => new UserRecipeListItem
                   {
                       Id = e.Id,
                       RecipeId = e.RecipeId,
                       Notes = GetNotesByUserRecipeId(e.Id),
                       UserId = e.UserId,
                   }
                   );
                return userRecipe.ToArray();
            }
        }
        //public bool UpdateUserRecipeAddNote(NoteCreate model, int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .UserRecipes
        //                .Single(e => e.Id == id && e.User.Id == _userId.ToString());

        //        var noteService = CreateNoteService();
        //        noteService.CreateNote(model);

        //        return true; 
        //    }
        //}


        //DELETE By UserRecipe ID ID for multiple entries... 

        public bool DeleteUserRecipe(int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserRecipes
                        .Single(e => e.Id == recipeId);

                ctx.UserRecipes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        private NoteService CreateNoteService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            NoteService noteService = new NoteService(_userId);
            return noteService;
        }
    }
}
