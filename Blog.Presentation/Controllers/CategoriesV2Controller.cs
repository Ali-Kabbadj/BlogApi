using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Presentation.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesV2Controller : ControllerBase
    {
        private readonly IServiceManager _service;
        public CategoriesV2Controller(IServiceManager service) => _service = service;

        [HttpGet(Name = "GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _service.CategoryService.GetAllCategoriesAsync(trackChanges: false);
            return Ok(categories);
        }

    }
}
