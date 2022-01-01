using BlogTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTaskDB.DAL.Repository.InterfaceRepo
{
   public interface IGroupReositoryG:IGenericRepository<Group>
    {

        List<Group> GetGroupsSuggestion(string userId);
        List<Group> GetGroupsNOtRejected(string userId);
        List<Group> GetAllGroupsForuser(string userId);
        List<Group> GetPendingGroups(string userId);
    }
}
