using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BloggingSystem.Models;
using BloggingSystem.Repository;
using BloggingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BloggingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IGenericRepository<Category> _category;
        public CategoryController(IGenericRepository<Category> category)
        {
            _category = category;
        }

        [Authorize(Roles ="Moderator , Blogger")]
        [HttpPost("AddCategory")]
        public async Task<ActionResult<Response>> AddCategory([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {

                return Ok(await _category.AddEntityAsync(category));
            }
            return BadRequest(new Response { Message = " There is a rowang" });
        }


        [Authorize(Roles = "Moderator , Blogger")]
        [HttpDelete("DeleteCategory")]
        public async Task<ActionResult<Response>> DeleteCategory([FromQuery] string categoryId)
        {
            if (categoryId != null)
            {

                return Ok(await _category.DeleteEntityAsync(categoryId));
            }
            return BadRequest(new Response { Message = " There is a rowang" });
        }


        [Authorize(Roles = "Moderator , Blogger")]
        [HttpPost("EditCategory")]
        public async Task<ActionResult<Response>> EditCategory([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {

                return Ok(await _category.UpdateEntityAsync(category));
            }
            return BadRequest(new Response { Message = " There is a rowang" });
        }


        [HttpGet("GetCategory")]
        public ActionResult<Category> GetCategory([FromQuery] string categoryId)
        {
            if (categoryId != null)
            {
                var category = _category.GetEntityByConditionAsync(x => x.Id == categoryId);
                return Ok(category);
            }
            return BadRequest();
        }

        [HttpGet("GetAllCategories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {

            return Ok(await _category.GetAllEntitiesAsync());
        }
    }
}
