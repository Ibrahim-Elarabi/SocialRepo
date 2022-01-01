using BlogTask.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTask.Models
{
    public class Group
    {
        public Group()
        {
            GroupUsers = new HashSet<GroupUser>();
            // Posts = new HashSet<Post>();
        }
        public int GroupID { get; set; }
        [Required]
        [MinLength(3,ErrorMessage ="Min Length is 3")]
        [MaxLength(10,ErrorMessage ="Max Length Is 10")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual ICollection<GroupUser> GroupUsers { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
