using BlogTask.Data;
using BlogTask.Models;
using BlogTaskDB.DAL.Paginattion;
using BlogTaskDB.DAL.Repository.InterfaceRepo;
using BlogTaskDB.DAL.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTaskDB.DAL.Repository.ClassRepo
{
    public class PostRepositoryG:GenericRepository<Post>, IPostRepositoryG
    {
        public PostRepositoryG(BlogTaskContext context):base(context)
        {

        }
        public List<Post> GetAllPostsInGroup(int id)
        {
            try
            {
                return Context.Posts.Where(p => p.GroupID == id).ToList();
            }
            catch (Exception)
            {

                return new List<Post>();
            }
        }

        //public IQueryable<Post> GetAllAs()
        //{
        //    return Context.Posts.Where(p=>p.UserId != null && p.GroupID == null).AsQueryable();
        //}
        public override IQueryable<Post> GetAllAsQueryable()
        {
            try
            {
                return Context.Posts.Where(p => p.UserId != null && p.GroupID == null).AsQueryable().OrderByDescending(p=>p.Date);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public   IQueryable<Post>  SearchGRoup(SearchDataVM filter)
        {
            IQueryable<Post> posts = Context.Posts.AsQueryable().OrderByDescending(p=>p.Date);
            if (filter != null)
            {
              
                if (filter.SearchText != null )
                {
                     posts =posts.Where(p => p.GroupID == filter.GroupID && p.Title ==filter.SearchText);
                }
                if ( filter.StartDate != null && filter.EndDate != null)
                {
                    posts = posts.Where(p => p.GroupID ==filter.GroupID && p.Date >filter.StartDate && p.Date <=filter.EndDate);
                }
                if (filter.SelectedIds != null)
                {
                    posts = posts.Where(p => p.GroupID == filter.GroupID && filter.SelectedIds.Contains(p.UserId));
                }
            }
            return posts;

        }
        public IQueryable<Post> GetAllPostsInGroupAsQueryAble(int groupid)
        {
            try
            {
                return Context.Posts.Where(p => p.GroupID == groupid).AsQueryable().OrderByDescending(p=>p.Date);
            }
            catch (Exception)
            {

                throw;
            }

        }

      
    }
}
