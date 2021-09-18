
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.Models
{
    public class BloggingDbContext :DbContext
    {
        public BloggingDbContext(DbContextOptions<BloggingDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { set; get; }
        public DbSet<Comment> Comment { set; get; }
        public DbSet<Post> Post { set; get; }
        public DbSet<PostPics> PostPics { set; get; }
        public DbSet<PostVideos> PostVideos { set; get; }
        public DbSet<Role> Role { set; get; }
        public DbSet<RoleUser> RoleUser { set; get; }
        public DbSet<Category> Category { set; get; }

    }
}
