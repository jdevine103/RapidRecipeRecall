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

        //This would be getting all MyRecipes and MyFavorites at the same time 
        //public IHttpActionResult GetByUserId()
        //{
        //    UserRecipeService postService = CreateUserRecipeService();
        //    var post = postService.GetAllUserRecipes();
        //    return Ok(post);
        //}

        [Route("MyRecipes")]
        public IHttpActionResult Get([FromUri] string id)
        {
            UserRecipeService userRecipeService = CreateUserRecipeService();
            var userRecipe = userRecipeService.GetMyRecipesByUserId(id);
            return Ok(userRecipe);
        }

        [Route("MyFavorites")]
        public IHttpActionResult GetMyFavorites([FromUri] string id)
        {
            UserRecipeService userRecipeService = CreateUserRecipeService();
                var userRecipe = userRecipeService.GetMyFavoritesByUserId(id);
                return Ok(userRecipe);
        }

        [Route("RecipeNotes")]
        public IHttpActionResult GetMyNotes([FromUri] int id)
        {
            UserRecipeService userRecipeService = CreateUserRecipeService();
            var userRecipe = userRecipeService.GetNotesByUserRecipeId(id);
            return Ok(userRecipe);
        }

        //public IHttpActionResult Put([FromUri] int id, [FromBody] NoteCreate noteForUserRecipe)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var service = CreateUserRecipeService();

        //    if (!service.UpdateUserRecipeAddNote(noteForUserRecipe, id))
        //        return InternalServerError();
        //    return Ok();
        //}

        //public IHttpActionResult Delete(int id)
        //{
        //    var service = CreateUserRecipeService();

        //    if (!service.DeleteUserRecipe(id))
        //        return InternalServerError();

        //    return Ok();
        //}

    }
}
