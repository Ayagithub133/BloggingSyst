using BloggingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.Repository
{
    public interface ITokenService
    {

        public Task<string> BuildToken(ApplicationUser user);
        public Task<bool> IsTokenValid();
    }
}
