using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BloggingSystem.Models;
using BloggingSystem.Paging;
using BloggingSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BloggingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SearchController : ControllerBase
    {
        private readonly IGenericRepository<Post> _post;
        public SearchController (IGenericRepository<Post> post)
        {
            _post = post;
        }

        [HttpGet("Filter")]
        public  ActionResult<IEnumerable<Post>> Filter ([FromQuery] string CategoryId)
        {
            
            if(!string.IsNullOrEmpty(CategoryId))
            {
                var Posts =  _post.GetListByConditionAsync(x => x.CategoryId == CategoryId).Result.OrderByDescending(x => x.PublishedAt).ToList();
                return Ok(Posts);
            }
            return Ok(null);
        }

        [HttpGet("Paging")]
        public async Task<ActionResult<IEnumerable<BaseEntity>>> Pagination([FromQuery] PaginationParameters parameters)
        {
            var queryable =  _post.GetTable();
            if (!string.IsNullOrEmpty(parameters.CategoryId))
            {
                queryable = queryable.Where(x =>x.CategoryId == parameters.CategoryId);
            }
           await HttpContext.INsertPaginationParametersInResponse<Post>(queryable, 10);
            var posts = queryable.Pagnate<Post>(parameters).ToList();
            return (posts);
        }


    }


    
}
