using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.Models
{
    public class Category : BaseEntity
    {
        [Column(TypeName ="nvarchar(20)")]
        [MinLength(3)]
        public string Name { set; get; }

        public List<Post> Posts { set; get; }
    }
}
