﻿using Microsoft.AspNet.Identity;
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
    public class RecipeController : ApiController
    {
        private RecipeService CreateRecipeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var recipeService = new RecipeService(userId);
            return recipeService;
        }

    public IHttpActionResult Get([FromBody]string name)
    {
        RecipeService recipeService = CreateRecipeService();
        var recipe = recipeService.GetRecipeByName(name);
        return Ok(recipe);
    }

        public IHttpActionResult Get()
        {
            RecipeService postService = CreateRecipeService();
            var post = postService.GetAllRecipes();
            return Ok(post);
        }

        public IHttpActionResult Post(RecipeCreate recipe)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRecipeService();

            if (!service.CreateRecipe(recipe))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            RecipeService postService = CreateRecipeService();
            var post = postService.GetRecipeById(id);
            return Ok(post);
        }

        public IHttpActionResult Put([FromUri] int id, [FromBody] RecipeEdit updatedRecipe)

        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateRecipeService();

            if (!service.UpdateRecipe(updatedRecipe, id))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateRecipeService();

            if (!service.DeleteRecipe(id))
                return InternalServerError();

            return Ok();
        }

    }
}
