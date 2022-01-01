using BlogTask.Data;
using BlogTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogTaskDB.DAL.Paginattion;

namespace BlogTask.Repository
{
    public class GroupRepository : IGroupReository
    {
        BlogTaskContext Db;
        public GroupRepository(BlogTaskContext _Db)
        {
            Db = _Db;
        }
        public void Add(Group group)
        {
            Db.Groups.Add(group);
        }

        public void Delete(int id)
        {
            var group = Db.Groups.Find(id);
            if (group != null)
                Db.Groups.Remove(group);
        }

        public IEnumerable<Group> GetAll()
        {
            return Db.Groups.ToList();
        }

        public Group GetByID(int id)
        {
            return Db.Groups.Find(id);
        }

        public bool Save()
        {
            int count = Db.SaveChanges();
            if (count > 0) return true;
            else return false;
        }

        public void Update(Group group)
        {
            if (group != null)
            {
                Db.Entry(group).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }
        public List<Group> GetGroupsSuggestion(string userId)
        {
            
            try
            {
                var groups = GetGroupsNOtREjected(userId);
                if(groups.Count > 0)
                {
                    //var groupSuggestion = Db.Groups.AsEnumerable().Except(groups).ToList();
                    var groupSuggestion = Db.Groups.Where(p => !groups.Contains(p)).ToList();

                    return groupSuggestion;
                }
                return new List<Group>();
                
            }
            catch (Exception)
            {

                return new List<Group>();
            }
        }

        public List<Group> GetGroupsNOtREjected(string userId)
        {
            try
            {
                var groupsNotAssign = Db.Groups.Include(p => p.GroupUsers).Where(p => p.GroupUsers.Any(p => p.UserId == userId && p.StatusRequset != StatusRequset.Reject)).ToList();
                //var groupsID = Db.GroupUsers.Where(p =>(p.UserId == userId && p.StatusRequset != StatusRequset.Reject )                            
                //).Select(g => g.GroupID).ToList();
                //List<Group> groups = new List<Group>();
                //foreach (var item in groupsID)
                //{
                //    groups.Add(Db.Groups.FirstOrDefault(g => g.GroupID == item));

                //}
                return groupsNotAssign;
            }
            catch (Exception)
            {

                return new List<Group>(); 
            }
        }
        public List<Group> GetPendingGroups(string userId)
        {
            //var groupsId = Db.GroupUsers.Where(g => g.UserId == userId && g.StatusRequset == StatusRequset.Pending)
            //                            .Select(g => g.GroupID);
            //List<Group> groups = new List<Group>();
            //foreach (var item in groupsId)
            //{
            //    groups.Add(Db.Groups.FirstOrDefault(g => g.GroupID == item));
            //}
            var groups = Db.Groups.Include(p => p.GroupUsers).Where(p => p.GroupUsers.Any(p => p.UserId == userId && p.StatusRequset == StatusRequset.Pending)).ToList();
            return groups;
        }
        public List<Group> GetAllGroupsForuser(string userId)
        {
            var groups = Db.Groups.Include(p => p.GroupUsers).Where(p => p.GroupUsers.Any(p => p.UserId == userId && p.StatusRequset == StatusRequset.Accept)).ToList();
            #region Bad Code
            //var groupsID = Db.GroupUsers.Where(p => p.UserId == userId && p.StatusRequset ==StatusRequset.Accept).Select(g => g.GroupID).ToList();
            //List<Group> groups = new List<Group>();
            //foreach (var item in groupsID)
            //{
            //    groups.Add(Db.Groups.FirstOrDefault(g => g.GroupID == item));

            //} 
            #endregion
            return groups;
        }
        public async Task<PaginatedList<Group>> GetAll(int pageIndex =1,int pageSize = 2)
        {
            var groups = await PaginatedList<Group>.CreateAsync( Db.Groups.AsQueryable(), pageIndex, pageSize);
            return groups;
        }
        public  IQueryable<Group> GetAllQU()
        {
            return Db.Groups.AsQueryable();
        }
    }
}
