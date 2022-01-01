using BlogTask.Areas.Identity.Data;
using BlogTask.Data;
using BlogTask.Models;
using BlogTaskDB.DAL.Repository.InterfaceRepo;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTaskDB.DAL.Repository.ClassRepo
{
    public  class GroupUserRepositoryG:GenericRepository<GroupUser> , IGroupUserRepositoryG
    {
        public GroupUserRepositoryG(BlogTaskContext context):base(context)
        {

        }

        public List<GroupUser> GetListGroupUsers(int id)
        {
            try
            {
                return Context.GroupUsers.Where(g => g.GroupID == id && g.StatusRequset == StatusRequset.Pending).ToList();
            }
            catch (Exception)
            {

                return new List<GroupUser>();
            }
        }

        public int GetNumbersOfUserInGroup(int id)
        {
            return Context.GroupUsers.Where(g => g.GroupID == id && g.StatusRequset == StatusRequset.Accept).Count();
        }

        //public List<IdentityUser>
        public List<IdentityUser> GetUsers(int id)
        {
           var users = Context.GroupUsers.Where(p => p.GroupID == id && p.StatusRequset == StatusRequset.Accept)
                                          .Select(p => p.IdentityUser).ToList();
            return users;
        }
    }
}
