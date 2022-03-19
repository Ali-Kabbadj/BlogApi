using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Microsoft.AspNetCore.JsonPatch;
using Blog.Presentation.ActionFilters;
using Shared.RequestFeatures;
using System.Text.Json;
using Entities.LinkModels;

namespace Blog.Presentation.Controllers
{
    [Route("api/categories/{categoryId}/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ArticlesController(IServiceManager service) => _service = service;


        [Route("/api/articles")]
        [HttpGet]
        [HttpHead]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        public async Task<IActionResult> GetAllActicles([FromQuery] ArticleParameters articleparams)
        {

            var linkParams = new LinkParameters(articleparams, HttpContext);
            var result = await _service.ArticleService.GetAllArticlesAsync(linkParams, trackChanges: false);
            Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(result.metaData));
            return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) :Ok(result.linkResponse.ShapedEntities);

        }


        [HttpGet]
        [HttpHead]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        public async Task<IActionResult> GetArticlesInCategory(Guid categoryId,[FromQuery] ArticleParameters articleparams)
        {

            var linkParams = new LinkParameters(articleparams, HttpContext);
            var result = await _service.ArticleService.GetAllArticlesInCategoryAsync(categoryId,linkParams, trackChanges: false);
            Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(result.metaData));
            return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) :Ok(result.linkResponse.ShapedEntities);

        }

    
        [HttpGet("{id:guid}", Name = "GetArticleInCategory")]
        public async Task<IActionResult> GetArticleInCategory(Guid id, Guid categoryId)
        {
             var article =await _service.ArticleService.GetArticleAsync(id,categoryId, trackChanges: false);
             return Ok(article);
        }


        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateArticleInCategory(Guid categoryId, [FromBody] ArticleForCreationDto article)
        {
            var articleToReturn =await _service.ArticleService.CreateArticleForCategoryAsync(categoryId, article, trackChanges: false);
            return Ok(CreatedAtRoute("GetArticleInCategory", new
            {
                categoryId,
                id = articleToReturn.Id
            }, articleToReturn));
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteArticleInCategory(Guid categoryId, Guid id)
        {
            await _service.ArticleService.DeleteArticleInCategoryAsync(categoryId, id, trackChanges:false);
            return NoContent();
        }


        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateArticleInCategory(Guid categoryId ,Guid id ,[FromBody] ArticleForUpdateDto article)
        {
            await _service.ArticleService.UpdateArticleInCategoryAsync(categoryId, id,article, compTrackChanges: false, empTrackChanger: true);
            return NoContent();
        }


        [HttpPatch("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> PartiallyUpdateArticleInCategory(Guid categoryId, Guid id,[FromBody] JsonPatchDocument<ArticleForUpdateDto> patchDoc)
        {
            var (articleToPatch, articleEntity) = await _service.ArticleService.GetArticleForPatchAsync(categoryId, id, compTrackChanges: false, empTrackChanges: true);

            patchDoc.ApplyTo(articleToPatch,ModelState);

            TryValidateModel(articleToPatch);

            await _service.ArticleService.SaveChangesForPatchAsync(articleToPatch, articleEntity);
            return NoContent();
        }



    }
}
