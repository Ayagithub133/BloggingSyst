using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.Models
{
    public class Role : BaseEntity
    {
        [Column(TypeName = "nvarchar(100)")]
        public string Name { set; get; }

        public List<RoleUser> roleUsers { set; get; }
    }
}
