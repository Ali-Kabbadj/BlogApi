using Blog.Presentation.ActionFilters;
using Blog.Presentation.Extensions;
using Blog.Presentation.ModelBinders;
using Entities.Responses;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Blog.Presentation.Controllers
{
    [Route("api/categories")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CategoriesController : ApiControllerBase
    {
        private readonly IServiceManager _service;
        public CategoriesController(IServiceManager service) => _service = service;

      
      
        /// <summary> 
        /// Gets the list of all categories
        /// </summary>
        /// <returns>The categories list</returns>
        [HttpGet(Name = "GetCategories")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetCategories()
        {
            var baseResult = await _service.CategoryService.GetAllCategoriesAsync(trackChanges: false);
            var categories = baseResult.GetResult<IEnumerable<CategoryDto>>();
            return Ok(categories);
        }



        [HttpGet("{id}", Name = "CategoryById")]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)] 
        [HttpCacheValidation(MustRevalidate = true)]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var baseResult = await _service.CategoryService.GetCategoryAsync(id, trackChanges: false);
            if(!baseResult.Success){
                return ProcessError(baseResult);
            }
            var category =  baseResult.GetResult<CategoryDto>();
            return Ok(category);
        }


        
        /// <summary> 
        /// Creates a newly created category 
        /// </summary> 
        /// <param name="category"></param> 
        /// <returns>A newly created company</returns> 
        /// <response code="201">Returns the newly created item</response> 
        /// <response code="400">If the item is null</response> 
        /// <response code="422">If the model is invalid</response>
        [ProducesResponseType(201)] 
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [HttpPost(Name = "CreateCategory")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto category)
        {
            var createdCategory = await _service.CategoryService.CreateCategoryAsync(category);
            return CreatedAtRoute("CategoryById", new { id = createdCategory.Id }, createdCategory);
        }



        [HttpGet("collection/({ids})", Name = "CategoryCollection")]
        public async Task<IActionResult> GetCategoryCollection([ModelBinder(BinderType =typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        {
            var categories = await _service.CategoryService.GetByIdsAsync(ids, trackChanges: false);
            return Ok(categories);
        }


        [HttpPost("collection")]
        public async Task<IActionResult> CreateCategoryCollection([FromBody] IEnumerable<CategoryForCreationDto> categoryCollection)
        {
            var (categories, ids) = await _service.CategoryService.CreateCategoryCollectionAsync(categoryCollection);
            return CreatedAtRoute("CategoryCollection", new { ids }, categories);
        }



        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _service.CategoryService.DeleteCategoryAsync(id, trackChanges: false);
            return Ok("Category Deleted");
        }



        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCategory(Guid id ,[FromBody]  CategoryForUpdateDto category)
        {
            await _service.CategoryService.UpdateCategoryAsync(id ,category, trackChanges: true);
            return Ok(category);
        }


        [HttpOptions]
        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST,PUT, DELETE");
            return Ok();
        }


    }
}
