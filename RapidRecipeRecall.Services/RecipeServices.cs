﻿using RapidRecipeRecall.Data;
using RapidRecipeRecall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RapidRecipeRecall.Services;

namespace RapidRecipeRecall.Services
{
    public class RecipeService
    {
        private readonly Guid _userId;

        public RecipeService(Guid userId)
        {
            _userId = userId;
        }

        private UserRecipeService CreateUserRecipeService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var userRecipeService = new UserRecipeService(_userId);
            return userRecipeService;
        }
        public bool CreateRecipe(RecipeCreate model)
        {
            bool saved;

            var entity =
                new Recipe()
                {
                    //EnteredBy = model.EnteredBy,
                    RecipeName = model.RecipeName,
                    RecipeAuthor = model.RecipeAuthor,
                    IsPublic = model.IsPublic,
                    Ingredients = model.Ingredients,
                    Instructions = model.Instructions,
                    Category = model.Category,
                    UserId = _userId.ToString()
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
                saved = ctx.SaveChanges() == 1;
            }

            var service = CreateUserRecipeService();
            service.CreateUserRecipeAuto(entity);

            return saved;
        }


        public IEnumerable<CommentListItem> GetCommentsByRecipeId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                  ctx
                      .Recipes
                      .FirstOrDefault(e => e.RecipeId == id);

                IEnumerable<Comment> comments = entity.Comments;

                return CreateListOfComments(comments);
            }
        }

        private IEnumerable<CommentListItem> CreateListOfComments(IEnumerable<Comment> comments)
        {

            List<CommentListItem> commentListItems = new List<CommentListItem>();

            foreach (Comment comment in comments)
            {
                CommentListItem i = new CommentListItem 
                {
                    CommentId = comment.CommentId,
                    Text = comment.Text,
                    RecipeId = comment.RecipeId,

                };
                commentListItems.Add(i);
            }
            return commentListItems;
        }

        public IEnumerable<RecipeListItem> GetAllRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Where(e => e.IsPublic)
                        .Select(
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
                        .Single(e => e.RecipeId == id && e.IsPublic == true);
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
                        .Single(e => e.RecipeId == id && e.UserId == _userId.ToString());
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
                        .Single(e => e.RecipeId == recipeId && e.UserId == _userId.ToString());

                ctx.Recipes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
