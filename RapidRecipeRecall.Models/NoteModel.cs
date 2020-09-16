using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidRecipeRecall.Models
{
    public class NoteCreate
    {
        public int NoteId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int UserRecipeId { get; set; }
    }

    public class NoteDetail
    {
        public int NoteId { get; set; }
        public string Text { get; set; }
        public int UserRecipeId { get; set; }
    }

    public class NoteEdit
    {
        public string Text { get; set; }
    }

    public class NoteListItem
    {
        public int NoteId { get; set; }
        public string Text { get; set; }
        public int UserRecipeId { get; set; }
    }
}
