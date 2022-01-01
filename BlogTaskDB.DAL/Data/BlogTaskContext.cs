using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogTask.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogTask.Data
{
    public class BlogTaskContext : IdentityDbContext<IdentityUser>
    {
        public BlogTaskContext(DbContextOptions<BlogTaskContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupUser> GroupUsers { get; set; }
    }
}
