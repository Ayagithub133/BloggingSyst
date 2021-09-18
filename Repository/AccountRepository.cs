using BloggingSystem.Models;
using BloggingSystem.ViewModels;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IGenericRepository<ApplicationUser> _user;
        private ISeedingRoles _seed;


        public AccountRepository(IGenericRepository<ApplicationUser> user,
            ISeedingRoles seed)
        {
            _user = user;
            _seed = seed;
           
        }

        public async Task<ApplicationUser> LoginAsync(string Password, string Email)
        {
           return await _user.GetEntityByConditionAsync(x => x.Email == Email
                 && x.HashPassword == WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(Password)));
        }

        public async Task<Response> RegisterationAsync(ApplicationUser user)
        {
            await _user.AddEntityAsync(user);
            return new Response { Message = "Done", IsSuccess = true };
        }

        public async Task<Response> RegisterModeratorAsync(ApplicationUser user)
        {
            await _user.AddEntityAsync(user);
            await _seed.seedRoles(user.Id);
            
            return new Response { Message = "Done", IsSuccess = true };
        }
    }
}
