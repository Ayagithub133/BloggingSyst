using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class PostController : ControllerBase
    {
        private readonly IGenericRepository<Post> _post;
        public PostController(IGenericRepository<Post> post)
        {
            _post = post;
        }

        [Authorize("Blogger")]
        [HttpPost("AddPost")]
        public async Task<ActionResult<Response>> AddPost([FromBody] Post post)
        {
            if (ModelState.IsValid)
            {
               
                return Ok(await _post.AddEntityAsync(post));
            }
            return BadRequest(new Response {Message =" There is a rowang" });
        }


        [Authorize("Blogger")]
        [HttpDelete("DeletePost")]
        public async Task<ActionResult<Response>> DeletePost([FromQuery] string postId)
        {
            if (postId!=null)
            {

                return Ok(await _post.DeleteEntityAsync(postId));
            }
            return BadRequest(new Response { Message = " There is a rowang" });
        }


        [Authorize("Moderator , Blogger")]
        [HttpPost("EditPost")]
        public async Task<ActionResult<Response>> EditPost([FromBody] Post post)
        {
            if (ModelState.IsValid)
            {

                return Ok(await _post.UpdateEntityAsync(post));
            }
            return BadRequest(new Response { Message = " There is a rowang" });
        }

        [AllowAnonymous]
        [HttpGet("GetPost")]
        public ActionResult<Post> GetPost([FromQuery] string postId)
        {
            if (postId!=null)
            {
                var post = _post.GetTable().Include(x => x.Videos).
                    Include(x => x.Pics).Include(x => x.Comments).Where(x=>x.Id == postId);
              
                return Ok(post);
            }
            return BadRequest();
        }

        [AllowAnonymous]
        [HttpGet("GetAllPosts")]
        public async Task<ActionResult<IEnumerable<Post>>> GetAllPost()
        {
           
            return Ok(await _post.GetAllEntitiesAsync());
        }
    }
}
