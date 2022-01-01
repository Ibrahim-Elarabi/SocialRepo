using BlogTask.Data;
using BlogTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTask.Repository
{
    public class PostRepository : IPostRepository
    {
        BlogTaskContext Db;
        public PostRepository(BlogTaskContext _Db)
        {
            Db = _Db;
        }
        public void Add(Post post,string userId)
        {
            post.UserId = userId;
            post.Date = DateTime.Now;
            Db.Posts.Add(post);
            
        }

        public void Delete(int PostId)
        {
            var post = Db.Posts.Find(PostId);
            if (post != null)
            {
                Db.Posts.Remove(post);
            }
           
        }

        public IEnumerable<Post> GetPublicPosts(string userId)
        {
            try
            {
                var posts = Db.Posts.Include(n => n.Blog).Where(p => p.UserId != null && p.GroupID == null).ToList();
                return posts;
            }
            catch (Exception)
            {

                return new List<Post>();
            }
        }

        public Post GetByID(int postId)
        {
            return Db.Posts.Include(n => n.Blog).FirstOrDefault(p=>p.PostID==postId);
        }

        public bool Save()
        {
           int count = Db.SaveChanges();
            if (count > 0) return true;
            else return false;
        }

        public void Update(Post post)
        {
            if(post != null)
            {
                Db.Entry(post).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }
         public List<Post> GetAllPostsInGroup(int id)
        {
           return Db.Posts.Where(p => p.GroupID == id).ToList();
        }

        public List<Post> GetPostsForUserByEmail(string email)
        {
            return Db.Posts.Where(p => p.IdentityUser.Email == email && p.GroupID ==null).ToList();
        }
    }
}
