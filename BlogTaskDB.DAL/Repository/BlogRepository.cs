//using BlogTask.Models;

using BlogTask.Data;
using BlogTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTask.Repository
{
    public class BlogRepository : IBlogRepository

    {
        BlogTaskContext blogContext;
        public BlogRepository(BlogTaskContext _blogContext)

        {
            blogContext = _blogContext;
        }
        public void Add(Blog blog)
        {
            
            blogContext.Blogs.Add(blog);
            
        }

        public void Delete(int BlogId)
        {
            var blog = blogContext.Blogs.Find(BlogId);
            if (blog != null)
                blogContext.Blogs.Remove(blog);
        }

        public void Update(Blog blog)
        {
            if(blog != null)
            {
                blogContext.Entry(blog).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public IEnumerable<Blog> GetAll()
        {
            return blogContext.Blogs.ToList();
        }

        public Blog GetByID(int id)
        {
            return blogContext.Blogs.FirstOrDefault(b => b.BlogId == id);
        }
        //Comment ret 
        public bool Save()
        {
            int Count = blogContext.SaveChanges();
            if (Count > 0) return true;
            else return false;

        }
    }
}
