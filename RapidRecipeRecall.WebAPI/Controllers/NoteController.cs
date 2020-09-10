using Microsoft.AspNet.Identity;
using RapidRecipeRecall.Models;
using RapidRecipeRecall.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RapidRecipeRecall.WebAPI.Controllers
{
    public class NoteController : ApiController
    {
        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new NoteService(userId);
            return noteService;
        }

        //public IHttpActionResult Post(NoteCreate note)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var service = CreateNoteService();

        //    if (!service.CreateNote(note))
        //        return InternalServerError();

        //    return Ok();
        //}

        //public IHttpActionResult Get()
        //{
        //    NoteService postService = CreateNoteService();
        //    var post = postService.GetAllNotes();
        //    return Ok(post);
        //}

        public IHttpActionResult Get(int id)
        {
            NoteService postService = CreateNoteService();
            var post = postService.GetNoteById(id);
            return Ok(post);
        }

        public IHttpActionResult Put([FromUri] int id, [FromBody] NoteEdit updatedNote)

        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateNoteService();

            if (!service.UpdateNote(updatedNote, id))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateNoteService();

            if (!service.DeleteNote(id))
                return InternalServerError();

            return Ok();
        }

    }
}
