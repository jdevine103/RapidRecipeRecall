using RapidRecipeRecall.Data;
using RapidRecipeRecall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidRecipeRecall.Services
{
    public class NoteService
    {
        private readonly Guid _userId;

        public NoteService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateNote(NoteCreate model)
        {
            var entity =
                new Note()
                {
                    NoteId = model.NoteId,
                    Text = model.Text,
                    UserRecipeId = model.UserRecipeId,
                   
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //public IEnumerable<NoteListItem> GetAllNotes()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //                .Notes
        //                .Where(e => e.)
        //                .Select(
        //                    e =>
        //                        new NoteListItem
        //                        {
        //                            NoteId = e.NoteId,
        //                            Text = e.Text,
        //                            UserRecipeId = e.UserRecipeId,
        //                        }
        //                );

        //        return query.ToArray();
        //    }
        //}


        public NoteDetail GetNoteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.UserRecipeId == id);
                return
                    new NoteDetail
                    {
                        NoteId = entity.NoteId,
                        Text = entity.Text,
                        UserRecipeId = entity.UserRecipeId,
                    };
            }
        }

        public bool UpdateNote(NoteEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == id);

                entity.Text = model.Text;                

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == noteId);

                ctx.Notes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
