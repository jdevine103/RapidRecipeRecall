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
    public class UserRecipeController : ApiController
    {
        //private UserRecipeService CreateUserRecipeService()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var userRecipeService = new UserRecipeService(userId);
        //    return userRecipeService;
        //}

        //public IHttpActionResult Post(UserRecipeCreate recipe)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var service = CreateUserRecipeService();

        //    if (!service.CreateUserRecipe(recipe))
        //        return InternalServerError();

        //    return Ok();
        //}


        //public IHttpActionResult Get()
        //{
        //    UserRecipeService postService = CreateUserRecipeService();
        //    var post = postService.GetAllUserRecipes();
        //    return Ok(post);
        //}

        //public IHttpActionResult Get(int id)
        //{
        //    UserRecipeService postService = CreateUserRecipeService();
        //    var post = postService.GetUserRecipeById(id);
        //    return Ok(post);
        //}

        //public IHttpActionResult Put([FromUri] int id, [FromBody] UserRecipeEdit updatedRecipe)

        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    var service = CreateUserRecipeService();

        //    if (!service.UpdateUserRecipe(updatedRecipe, id))
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
