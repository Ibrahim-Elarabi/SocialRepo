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
        //IQueryable<Post> GetPostInGroupFilterByTitle(int groupid, string title);

        //IQueryable<Post> GetPostInGroupFilterByDate(int groupid, DateTime startDate, DateTime endDate);
        //IQueryable<Post> GetPostInGroupFilterByUser(int groupid, string[] userID);
        //IQueryable<Post> GetPostInGroupFilterByTitleAndDate(int groupid, string title, DateTime startDate, DateTime endDate);
        //IQueryable<Post> GetPostInGroupFilterByTitleAndUser(int groupid, string title , string [] userID);
        //IQueryable<Post> GetPostInGroupFilterByDateAndUser(int groupid,  DateTime startDate, DateTime endDate , string[] userID);
        //IQueryable<Post> GetPostInGroupFilterByALlDate(int groupid, DateTime startDate, DateTime endDate, string[] userID,string title);



    }
}
