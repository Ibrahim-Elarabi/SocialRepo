using BlogTask.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTask.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public ApplicationUser()
        {
            Posts = new HashSet<Post>();
            //GroupUsers = new HashSet<GroupUser>();
        }
        public virtual ICollection <Post> Posts { get; set; }
        //public virtual ICollection<GroupUser> GroupUsers { get; set; }
    }
}
