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
    [RoutePrefix("api/UserRecipe")]
    public class UserRecipeController : ApiController
    {
        private UserRecipeService CreateUserRecipeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var userRecipeService = new UserRecipeService(userId);
            return userRecipeService;
        }

        public IHttpActionResult Post(UserRecipeCreate recipe)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserRecipeService();

            if (!service.CreateUserRecipe(recipe))
                return InternalServerError();

            return Ok();
        }


        //public IHttpActionResult Get()
        //{
        //    UserRecipeService postService = CreateUserRecipeService();
        //    var post = postService.GetAllUserRecipes();
        //    return Ok(post);
        //}

        [Route("MyRecipes")]
        public IHttpActionResult Get([FromUri] string id)
        {
            UserRecipeService postService = CreateUserRecipeService();
            var post = postService.GetMyRecipesByUserId(id);
            return Ok(post);
        }


        [Route("MyFavorites")]
        public IHttpActionResult GetMyFavorites([FromUri] string id)
        {
            UserRecipeService postService = CreateUserRecipeService();
                var post = postService.GetMyFavoritesByUserId(id);
                return Ok(post);
        }

        [Route("MyNotes")]
        public IHttpActionResult GetMyNotes([FromUri] int id)
        {
            UserRecipeService userRecipeService = CreateUserRecipeService();
            var post = userRecipeService.GetNotesByUserRecipeId(id);
            return Ok(post);
        }

        //public IHttpActionResult GetFavorites([FromUri] string id, [FromBody] bool addToFavorites)
        //{
        //    UserRecipeService postService = CreateUserRecipeService();
        //    if (addToFavorites == true)
        //    {
        //        var post = postService.GetMyFavoritesByUserId(id);
        //        return Ok(post);
        //    }
        //    return BadRequest("AddToFavorites is FALSE");
        //}

        public IHttpActionResult Put([FromUri] int id, [FromBody] NoteCreate noteForUserRecipe)
        {
            //updatedUserRecipeWithAddedNote.UserRecipeId = id;
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserRecipeService();

            if (!service.UpdateUserRecipeAddNote(noteForUserRecipe, id))
                return InternalServerError();
            return Ok();
        }

        //public IHttpActionResult Delete(int id)
        //{
        //    var service = CreateUserRecipeService();

        //    if (!service.DeleteUserRecipe(id))
        //        return InternalServerError();

        //    return Ok();
        //}

    }
}
