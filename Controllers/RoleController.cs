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

namespace Services.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Blogger")]
    public class RoleController : ControllerBase
    {

        private readonly IGenericRepository<Role> _role;
        public RoleController(IGenericRepository<Role> role)
        {
            _role = role;
        }

        [HttpPost("AddRole")]
        public async Task<ActionResult<Response>> AddRole([FromBody] Role role)
        {
            if (ModelState.IsValid)
            {

                return Ok(await _role.AddEntityAsync(role));
            }
            return BadRequest(new Response { Message = " There is a rowang" });
        }

        [HttpDelete("DeleteRole")]
        public async Task<ActionResult<Response>> DeleteRole([FromQuery] string roleId)
        {
            if (roleId != null)
            {

                return Ok(await _role.DeleteEntityAsync(roleId));
            }
            return BadRequest(new Response { Message = " There is a rowang" });
        }

        [HttpPost("EditRole")]
        public async Task<ActionResult<Response>> EditRole([FromBody] Role role)
        {
            if (ModelState.IsValid)
            {

                return Ok(await _role.UpdateEntityAsync(role));
            }
            return BadRequest(new Response { Message = " There is a rowang" });
        }


        [HttpGet("GetRole")]
        public ActionResult<Role> GetRole([FromQuery] string roleId)
        {
            if (roleId != null)
            {
                var role = _role.GetTable().Include(x => x.roleUsers).Where(x => x.Id == roleId);
                   
                return Ok(role);
            }
            return BadRequest();
        }

        [HttpGet("GetAllRoles")]
        public async Task<ActionResult<IEnumerable<Role>>> GetAllRoles()
        {

            return Ok(await _role.GetAllEntitiesAsync());
        }
    }
}
