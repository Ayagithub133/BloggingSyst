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
    public class CommentController : ControllerBase
    {

        private readonly IGenericRepository<Comment> _comment;
        public CommentController(IGenericRepository<Comment> comment)
        {
            _comment = comment;
        }

        [Authorize]
        [HttpPost("AddComment")]
        public async Task<ActionResult<Response>> AddComment([FromBody] Comment comment)
        {
            if (ModelState.IsValid)
            {
               
                await _comment.AddEntityAsync(comment);
                
                return Ok();
            }
            return BadRequest(new Response { Message = " There is a rowang" });
        }

        [Authorize]
        [HttpDelete("DeleteComment")]
        public async Task<ActionResult<Response>> DeleteComment([FromQuery] string commentId)
        {
            if (commentId != null)
            {

                return Ok(await _comment.DeleteEntityAsync(commentId));
            }
            return BadRequest(new Response { Message = " There is a rowang" });
        }

        [Authorize(Roles = "Moderator , Blogger")]
        [HttpPost("EditComment")]
        public async Task<ActionResult<Response>> EditComment([FromBody] Comment comment)
        {
            if (ModelState.IsValid)
            {

                return Ok(await _comment.UpdateEntityAsync(comment));
            }
            return BadRequest(new Response { Message = " There is a rowang" });
        }

        [Authorize(Roles="Moderator")]
        [HttpPost("AcceptComment")]
        public async Task<ActionResult<Response>> AcceptComment([FromQuery] string Id)
        {
            if (ModelState.IsValid)
            {
                var comment = await _comment.GetEntityByConditionAsync(x => x.Id == Id);
                comment.isAccept = true;
                return Ok(await _comment.UpdateEntityAsync(comment));
            }
            return BadRequest(new Response { Message = " There is a rowang" });
        }


        [HttpGet("GetComment")]
        public ActionResult<Comment> GetComment([FromQuery] string commentId)
        {
            if (commentId != null)
            {
                Comment comment = _comment.GetEntityByConditionAsync(x => x.Id == commentId).Result;
                if (comment.isAccept)
                {
                    return Ok(comment);
                }
                return Ok(null);
            }
            return BadRequest();
        }

        [HttpGet("GetAllComments")]
        public  ActionResult<IEnumerable<Comment>> GetAllComments()
        {

            return Ok(_comment.GetAllEntitiesAsync().Result.Where(x=>x.isAccept == true));
        }
    }
}
