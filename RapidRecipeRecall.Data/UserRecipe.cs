using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidRecipeRecall.Data
{
    public class UserRecipe
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        
        public bool AddToFavorites { get; set; }

        public List<Note> Notes { get; set; }
        //{
        //    get
        //    {
        //        using (var ctx = new ApplicationDbContext())
        //        {
        //            var query =
        //               ctx
        //                    .Notes
        //                    .Where(e => e.UserRecipe.UserId == User.Id && e.UserRecipeId == Id)
        //                    .ToList();
        //            return query;
        //        }
        //    }
        //}

    }
}
