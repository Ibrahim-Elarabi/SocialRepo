using BlogTask.Data;
using BlogTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTask.Repository
{
    public class GroupUserRepository : IGroupUserRepository
    {
        BlogTaskContext Db;
        public GroupUserRepository(BlogTaskContext _Db)
        {
            Db = _Db;
        }
        public void Add(GroupUser groupUser)
        {
            Db.GroupUsers.Add(groupUser);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public GroupUser GetByGroupIdUserId(string userId, int groupId)
        {
            return Db.GroupUsers.FirstOrDefault(p => p.GroupID == groupId && p.UserId == userId);
        }

        public GroupUser GetByID(int id)
        {
            return Db.GroupUsers.Find(id);
              
        }

        public List<GroupUser> GetListGroupUsers(int id)

        {
            
           //return Db.GroupUsers.Where(g => g.GroupID ==id && g.IsRequest == false).ToList();
            return Db.GroupUsers.Where(g => g.GroupID == id && g.StatusRequset == StatusRequset.Pending).ToList();

        }

        public bool Save()
        {

            int count = Db.SaveChanges();
            if (count > 0) return true;
            else return false;
        }

        public void Update(GroupUser groupUser)
        {
            throw new NotImplementedException();
        }
        public  List<GroupUser> GetAllGroupUsers()
        {
            return Db.GroupUsers.ToList();
        }

        public int GetNumbersOfUserInGroup(int id)
        {
            return Db.GroupUsers.Where(g => g.GroupID == id && g.StatusRequset == StatusRequset.Accept).Count();
        }
    }
}
