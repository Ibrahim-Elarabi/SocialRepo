using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTask.Models.ViewModel
{
    public class PostInGroupVM
    {
        public PostInGroupVM(Post post)
        {
            PostID = post.PostID;
            Title = post.Title;
            Content = post.Content;
            Date = post.Date.ToShortDateString();
            BlogID = post.BlogID;
            UserId = post.UserId;
            GroupId = post.GroupID;
            Email = post.IdentityUser.Email;
            
        }
        public int PostID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Date { get; set; }

        public int? BlogID { get; set; }

        public string UserId { get; set; }
        public int? GroupId { get; set; }

        public string Email { get; set; }
        //public string GroupName { get; set; }
        //public string GroupDesc { get; set; }
        public string CurrentUserId { get; set; }
        //public int NumberOfUserInGroup { get; set; }

    }
}
