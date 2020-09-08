using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidRecipeRecall.Data
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }

        [ForeignKey(nameof(User))]
        public string EnteredBy { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        public string RecipeName { get; set; }

        [Required]
        public string RecipeAuthor { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        public bool AddToMyList { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [Required]
        public string Instructions { get; set; }

        [Required]
        public Category Category { get; set; }

    }

    public enum Category
    {
        Appetizers, 
        Soups,
        Salads,
        Vegetables,
        Main_Dishes,
        Breads, 
        Desserts,
        Miscellaneous
    }

}
