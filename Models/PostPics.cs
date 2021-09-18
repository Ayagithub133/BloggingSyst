using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.Models
{
    public class PostPics:BaseEntity
    {
        public Post Post { set; get; }

        [ForeignKey("Post")]
        public string PostId { set; get; }

        [Column(TypeName = "nvarchar(max)")]
        public string PicPath { set; get; }
    }
}
