using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidRecipeRecall.Data
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }

        [Required]
        public string Text { get; set; }

        [ForeignKey(nameof(UserRecipe))]
        public int UserRecipeId { get; set; }
        public virtual UserRecipe UserRecipe { get; set; }      
        
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
