using BloggingSystem.Models;
using BloggingSystem.Repository;
using BloggingSystem.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BloggingSystem.DTO;

namespace BloggingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _auth;
        private readonly IGenericRepository<ApplicationUser> _user;
        private readonly ITokenService _token;

        public AccountController (IAccountRepository auth ,
           IGenericRepository<ApplicationUser> user, ITokenService token)
        {
            _auth = auth;
            _user = user;
            _token = token;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<Response>> Login([FromBody] LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _auth.LoginAsync(model.Password, model.Email);

                if(user!=null)
                {
                    var AppUser = User as ClaimsPrincipal;
                    var identity = AppUser.Identity as ClaimsIdentity;
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));

                    string token =  await _token.BuildToken(user);
                    return Ok(new { token = token});
                        
                }
                return Ok(new Response { Message = "Email Or Password Not Valid !" });

            }
            return BadRequest("Invalid client request");
        }

        [HttpPost("SignUpVisitor")]
        public async Task<ActionResult<Response>> SignUPVisitor(User user)
        {
            if(ModelState.IsValid)
            {
                var appUser = await _user.GetEntityByConditionAsync(x => x.Email == user.Email);
                if (appUser != null)
                {
                    return Ok(new Response(){Message =" That Email Already Exist"});
                }

                ApplicationUser applicationUser = Dto.TransfirmToApplicationUser(user);
               await _auth.RegisterationAsync(applicationUser);
                return Ok("Done");
            }
            return BadRequest(new Response { Message = "Invalid client request" });
        }

        [Authorize(Roles = "Blogger")]
        [HttpPost("SignUpModerator")]
        public async Task<ActionResult<Response>> SignUPModerator([FromBody] ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                await _auth.RegisterModeratorAsync(user);
            }
            return BadRequest(new Response { Message = "Invalid client request" });
        }

        [Authorize]
        [HttpGet("CurrentUser")]
        public ActionResult<Response> GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            List<Claim> claims = identity.Claims.ToList();
            var UserId = claims[0].Value;
            CurrentUser.CurrentUserId = UserId;
            if(UserId == null)
            {
                return Ok(new Response {IsSuccess = false });
            }
            return Ok(new Response { IsSuccess = true });
        }

        [Authorize]
        [HttpGet("LogOutUser")]
        public async Task<ActionResult> LogOutUser()
        {
            if (CurrentUser.CurrentUserId!= null)
            {
                var user = User as ClaimsPrincipal;
                var identity = user.Identity as ClaimsIdentity;
                var claim = (from c in user.Claims
                             where c.Value == CurrentUser.CurrentUserId
                             select c).Single();
                identity.RemoveClaim(claim);
            }
            await HttpContext.SignOutAsync();
            return Ok();
        }

    }
}
