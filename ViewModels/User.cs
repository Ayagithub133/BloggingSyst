using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.ViewModels
{
    public class User
    {
      
        [Required]
        [MinLength(3)]
        public string FName { set; get; }

      
        [Required]
        [MinLength(3)]
        public string LName { set; get; }

    
        [Required]
        [EmailAddress]
        public string Email { set; get; }

        [Required]
        [MinLength(10)]
        [RegularExpression("[A-Za-z1-9]{10,}")]
        public string HashPassword { set; get; }
    }
}
