using BloggingSystem.Models;
using BloggingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.Repository
{
    public interface IAccountRepository
    {
        public Task<ApplicationUser> LoginAsync(string Password, String Email);
        public Task<Response> RegisterationAsync(ApplicationUser user);
        public Task<Response> RegisterModeratorAsync(ApplicationUser user);
    }
}
