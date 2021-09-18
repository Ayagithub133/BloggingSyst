using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.Models
{
    public class RoleUser : BaseEntity
    {
        

        public Role Role { set; get; }
        [ForeignKey("Role")]
        public string RoleId { set; get; }

        public ApplicationUser User { set; get; }
        [ForeignKey("User")]
        public string UserId { set; get; }
    }
}
