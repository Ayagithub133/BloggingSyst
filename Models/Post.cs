using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.Models
{
    public class Post : BaseEntity
    {

        public Post()
        {
            this.PublishedAt = DateTime.Now;
        }
        [Column(TypeName = "nvarchar(max)")]
        [MinLength(1)]
        public string Text { set; get; }

        [Column(TypeName = "datetime")]
        public DateTime PublishedAt { set; get; }

        public ApplicationUser User { set; get; }

        [ForeignKey("User")]
        public string UserId { set; get; }

        public Category Category { set; get; }

        [ForeignKey("Category")]
        public string CategoryId { set; get; }

        public List<PostVideos> Videos { set; get; }
        public List<PostPics> Pics { set; get; }
        public List<Comment> Comments { set; get; }
    }
}
