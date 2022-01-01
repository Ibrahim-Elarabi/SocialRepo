using BlogTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTask.Repository
{
  public  interface IPostRepository
    {
        IEnumerable<Post> GetPublicPosts(string UserId);
        Post GetByID(int postId);
        void Add(Post post,string UserId);
        void Delete(int postId);
        void Update(Post post);
        List<Post> GetAllPostsInGroup(int id);
        bool Save();
        List<Post> GetPostsForUserByEmail(string email);
    }
}
