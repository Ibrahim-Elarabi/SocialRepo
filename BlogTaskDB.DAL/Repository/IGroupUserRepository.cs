using BlogTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTask.Repository
{
    public interface IGroupUserRepository
    {
        List<GroupUser> GetListGroupUsers(int id);

        GroupUser GetByID(int id);
        GroupUser GetByGroupIdUserId(string userId, int groupId);
        void Add(GroupUser groupUser);
        void Delete(int id);
        void Update(GroupUser groupUser);
        List<GroupUser> GetAllGroupUsers();
        bool Save();
        int GetNumbersOfUserInGroup(int id);
    }
}
