using BlogTask.Models;
using BlogTaskDB.DAL.Paginattion;
using BlogTaskDB.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTaskDB.DAL.Repository.InterfaceRepo
{
    public  interface IPostRepositoryG:IGenericRepository<Post>
    {
        List<Post> GetAllPostsInGroup(int id);
        IQueryable<Post> GetAllPostsInGroupAsQueryAble(int groupid);
        IQueryable<Post> SearchGRoup(SearchDataVM filter);
        
    }
}
