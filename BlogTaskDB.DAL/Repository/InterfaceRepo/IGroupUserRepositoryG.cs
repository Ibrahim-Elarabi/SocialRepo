using BlogTask.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTaskDB.DAL.Repository.InterfaceRepo
{
    public  interface IGroupUserRepositoryG:IGenericRepository<GroupUser>
    {
        List<GroupUser> GetListGroupUsers(int id);
        int GetNumbersOfUserInGroup(int id);
        List<IdentityUser> GetUsers(int id);
    }
}
