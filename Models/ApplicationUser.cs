using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.Models
{
    public class ApplicationUser : BaseEntity
    {
        public ApplicationUser() : base()
        {
            this.RegisteredAt = DateTime.Now;
        }

        [Column(TypeName ="nvarchar(20)")]
        [Required]
        [MinLength(3)]
        public string FName { set; get; }

        [Column(TypeName = "nvarchar(20)")]
        [Required]
        [MinLength(3)]
        public string LName { set; get; }

        [Column(TypeName = "varchar(200)")]
        [Required]
        [EmailAddress]
        public string Email { set; get; }

        [Required]
        [MinLength(10)]
        
        public string HashPassword { set; get; }

        [Column(TypeName = "datetime")]
        public DateTime RegisteredAt { set; get; }

        
        [Column(TypeName = "varchar(max)")]
        public string PicPath { set; get; }

        public List<Comment> Comments { set; get; }
        public List<Post> Posts { set; get; }
        public List<RoleUser>  roleUsers { set; get; } 
    }
}
