using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTask.Models.ViewModel
{
    public class PostVM
    {
        public PostVM(Post post )
        {
            PostID = post.PostID;
            Title = post.Title;
            Content = post.Content;
            Date = post.Date.ToShortDateString();
            BlogID = post.BlogID;
            UserId = post.UserId;
            
        }
        public int PostID { get; set; }
        
        public string Title { get; set; }
        
        public string Content { get; set; }
        
        public string Date { get; set; }
       
        public int? BlogID { get; set; }
       

        public string UserId { get; set; }
        public string Email { get; set; }

    }
}
