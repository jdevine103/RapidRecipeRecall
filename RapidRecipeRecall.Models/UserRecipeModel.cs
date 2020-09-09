using RapidRecipeRecall.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidRecipeRecall.Models
{
    public class UserRecipeCreate
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [Required]
        public string UserId { get; set; }

        public List<Note> Notes { get; set; }
    }


    public class UserRecipeDetail
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public string UserId { get; set; }

        public List<Note> Notes { get; set; }
    }

    public class UserRecipeEdit
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public string UserId { get; set; }

        public List<Note> Notes { get; set; }
    }

    public class UserRecipeListItem
    {
        public int Id { get; set; }
        
        public int RecipeId { get; set; }

        public string UserId { get; set; }

        public List<Note> Notes { get; set; }
    }
}
