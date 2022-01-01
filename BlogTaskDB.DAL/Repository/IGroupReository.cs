using BlogTask.Models;
using BlogTaskDB.DAL.Paginattion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTask.Repository
{
    public  interface IGroupReository
    {
        List<Group> GetGroupsSuggestion(string userId);
        IEnumerable<Group> GetAll();
        Group GetByID(int id);
        void Add(Group group);
        void Delete(int id);
        void Update(Group group);
        bool Save();
        List<Group> GetGroupsNOtREjected(string userId);
        List<Group> GetAllGroupsForuser(string userId);
        List<Group> GetPendingGroups(string userId);
         Task<PaginatedList<Group>> GetAll(int pageIndex = 1, int pageSize = 2);
        IQueryable<Group> GetAllQU();
    }
}
