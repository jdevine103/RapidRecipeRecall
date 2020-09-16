using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidRecipeRecall.Models
{
    public class CommentCreate
    {
        public int CommentId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int RecipeId { get; set; }

    }

    public class CommentDetail
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public int RecipeId { get; set; }
    
    }

    public class CommentEdit
    {
        public string Text { get; set; }
    }

    public class CommentListItem
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public int RecipeId { get; set; }
       
    }
}
