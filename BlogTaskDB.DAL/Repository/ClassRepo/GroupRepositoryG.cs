using BlogTask.Data;
using BlogTask.Models;
using BlogTaskDB.DAL.Repository.InterfaceRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTaskDB.DAL.Repository.ClassRepo
{
    public  class GroupRepositoryG:GenericRepository<Group>, IGroupReositoryG
    {
        public GroupRepositoryG(BlogTaskContext context):base(context)
        {

        }

        public List<Group> GetGroupsSuggestion(string userId)
        {

            try
            {
                var groups = GetGroupsNOtRejected(userId);
                if (groups.Count > 0)
                {
                    var groupSuggestion = Context.Groups.Where(p => !groups.Contains(p)).ToList();
                    return groupSuggestion;
                }
                return new List<Group>();

            }
            catch (Exception)
            {

                return new List<Group>();
            }
        }

        public List<Group> GetGroupsNOtRejected(string userId)
        {
            try
            {
                var groupsAssign = Context.Groups.Include(p => p.GroupUsers).Where(p => p.GroupUsers.Any(p => p.UserId == userId && p.StatusRequset != StatusRequset.Reject)).ToList();
              
                return groupsAssign;
            }
            catch (Exception)
            {

                return new List<Group>();
            }
        }

        public List<Group> GetAllGroupsForuser(string userId)
        {
            try
            {
                return Context.Groups.Include(p => p.GroupUsers).Where(p => p.GroupUsers.Any(p => p.UserId == userId && p.StatusRequset == StatusRequset.Accept)).ToList();
                
            }
            catch (Exception)
            {

                return new List<Group>();
            }
        }

        public List<Group> GetPendingGroups(string userId)
        {
            try
            {
                var groups = Context.Groups.Include(p => p.GroupUsers).Where(p => p.GroupUsers.Any(p => p.UserId == userId && p.StatusRequset == StatusRequset.Pending)).ToList();
                return groups;
            }
            catch (Exception)
            {

                return new List<Group>();
            }
        }
    }
}
