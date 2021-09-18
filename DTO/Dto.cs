using BloggingSystem.Models;
using BloggingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.DTO
{
    public static class Dto
    {
        public static ApplicationUser TransfirmToApplicationUser(User user)
        {
            return new ApplicationUser()
            {
                FName = user.FName,
                LName = user.LName,
                Email = user.Email,
                HashPassword = user.HashPassword
            };
        }
    }
}
