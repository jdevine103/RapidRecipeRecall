using RapidRecipeRecall.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidRecipeRecall.Models
{
    public class RecipeCreate
    {
        public string EnteredBy { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        public string RecipeName { get; set; }

        public string RecipeAuthor { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        [Required]
        public bool AddToMyList { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public string Instructions { get; set; }
        [Required]
        public Category Category { get; set; }
    }

    public class RecipeDetail
    {
        public string EnteredBy { get; set; }
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeAuthor { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public Category Category { get; set; }

    }

    public class RecipeEdit
    {
        public string EnteredBy { get; set; }
        public string RecipeName { get; set; }
        public string RecipeAuthor { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public Category Category { get; set; }
    }

    public class RecipeListItem 
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeAuthor { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public Category Category { get; set; }

    }
}
