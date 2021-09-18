using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.Models
{
    public class Comment : BaseEntity
    {
        public Comment()
        {
            this.PublishedAt = DateTime.Now;
        }
        [Column(TypeName ="nvarchar(100)")]
        [MinLength(1)]
        public string Text { set; get; }

        [Column(TypeName = "datetime")]
        public DateTime PublishedAt { set; get; }

        [Column(TypeName = "bit")]
        public bool isAccept { set; get; }

        public ApplicationUser User { set; get; }

        [ForeignKey("User")]
        public string UserId { set; get; }

        public Post Post { set; get; }

        [ForeignKey("Post")]
        public string PostId { set; get; }

    }
}
