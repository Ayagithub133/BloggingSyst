using BloggingSystem.Repository;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystem.Models
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(BloggingDbContext context)
        {
            if (context.Set<Role>().Count() == 0)
            {

                await context.Role.AddRangeAsync(new Role { Name = "Blogger", Id = "0e10eff5-ccd4-45d9-b516-4cf0497587f2" },
                    new Role { Name = "Visitor", Id = "2ef7e4be-5b08-4656-a6ea-e13669bde5b0" },
                    new Role { Name = "Moderator", Id = "3e40553a-9ecf-472e-935e-25f70392c828" });
                await context.SaveChangesAsync();
            }
            if (await context.Set<ApplicationUser>().FindAsync("3e40553a-9ecf-472e-935e-25f70392c828") == null)
            {
                await context.ApplicationUser.AddAsync(new ApplicationUser
                {
                    FName = "Aya",
                    LName = "Mohamed",
                    Email = "ayaa.mohamed133@gmail.com",
                    HashPassword = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes("Aya098")),
                    RegisteredAt = DateTime.Now.Date,
                    Id = "3e40553a-9ecf-472e-935e-25f70392c828"
                }) ;
                await context.SaveChangesAsync();
            }
        }

        public static async Task seedSuperAdminAsync(BloggingDbContext context)
        {
            if(await context.Set<ApplicationUser>().FindAsync("3e40553a-9ecf-472e-935e-25f70392c828") != null && 
                context.Set<Role>() != null && context.Set<RoleUser>().Count() == 0)
            {
                await context.Set<RoleUser>().AddRangeAsync(new RoleUser {RoleId = "0e10eff5-ccd4-45d9-b516-4cf0497587f2",UserId= "3e40553a-9ecf-472e-935e-25f70392c828" },
                    new RoleUser { RoleId= "3e40553a-9ecf-472e-935e-25f70392c828" , UserId= "3e40553a-9ecf-472e-935e-25f70392c828" }
                    );
                await context.SaveChangesAsync();
            }
          
        }
    }
}
