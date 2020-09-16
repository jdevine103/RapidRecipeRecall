using RapidRecipeRecall.Data;
using RapidRecipeRecall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidRecipeRecall.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

    public bool CreateComment(CommentCreate model)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var comment =
            new Comment()
            {
                CommentId = model.CommentId,
                Text = model.Text,
                RecipeId = model.RecipeId,
                UserId = _userId.ToString(),
            };
            ctx.Comments.Add(comment);
            return ctx.SaveChanges() == 1;
        }
    }

        public bool UpdateComment(CommentEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == id);

                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == commentId);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
