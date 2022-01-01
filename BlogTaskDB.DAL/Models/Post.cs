using BlogTask.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations.
using System.Linq;
using System.Threading.Tasks;

namespace BlogTask.Models
{
    public class Post
    {
        public int PostID { get; set; }
        [Required]
        public string Title { get; set; }
        [DisplayNameAttribute("Post Content")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage ="You Must Enter Post Content")]
        public string Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Img { get; set; }

        //public bool InPublic { get; set; }
        [ForeignKey("Blog")]
        public int? BlogID { get; set; }
        [ForeignKey(nameof(IdentityUser))]
        public string UserId { get; set; }

        [ForeignKey("Group")]
        public int? GroupID  { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }

        public virtual Group Group { get; set; }

    }
}
