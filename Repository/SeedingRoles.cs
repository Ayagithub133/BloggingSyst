using BloggingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.Repository
{
    public class SeedingRoles : ISeedingRoles
    {
        private readonly IGenericRepository<Role> _role;
        private readonly IGenericRepository<RoleUser> _roleUser;

        public SeedingRoles(IGenericRepository<Role> role,
            IGenericRepository<RoleUser> roleUser
            )
        {
            _role = role;
            _roleUser = roleUser;
            
        }


        public async Task seedRoles(string Id)
        {
          
            await _roleUser.AddEntityAsync(new RoleUser { UserId = Id,RoleId = GetRoleId().ToString()});
        }

        private async Task<string> GetRoleId()
        {
           var list = await _role.GetAllEntitiesAsync();
            return list.Where(x => x.Name.Contains("Moderator")).Select(x => x.Id).FirstOrDefault();
        }
    }
}
