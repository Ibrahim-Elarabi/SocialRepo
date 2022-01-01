using BlogTask.Models;
using BlogTaskDB.DAL.Repository.InterfaceRepo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogTask.Controllers
{
    public class GroupUserController : Controller
    {
        IGroupUserRepositoryG groupUserRepositoryG;
        public GroupUserController(IGroupUserRepositoryG _groupUserRepositoryG)
        {
            groupUserRepositoryG = _groupUserRepositoryG;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetJoinRequest(int id)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var groupUser = new GroupUser()
                {
                    GroupID = id,
                    UserId = userId,
                    //IsRequest = false
                    StatusRequset = StatusRequset.Pending,
                    Date = DateTime.Now
                };
                //groupUserRepository.Add(groupUser);
                groupUserRepositoryG.Add(groupUser);
                var isSaved = groupUserRepositoryG.Save();
                return Json(new { ok = isSaved });
            }
            catch (Exception)
            {

                return Json(new { ok = false });
            }
        }

        public IActionResult GetRequestsGroup(int id)
        {
            //var groupUserRequest = groupUserRepository.GetListGroupUsers(id);
            var groupUserRequest = groupUserRepositoryG.GetListGroupUsers(id);

            return PartialView("_GetRequestsGroup", groupUserRequest);

        }

        public IActionResult ConfirmRequest(int id)
        {

            try
            {

                var groupuser = groupUserRepositoryG.GetByID(id);
                if (groupuser != null)
                {
                    //groupuser.IsRequest = true;
                    groupuser.StatusRequset = StatusRequset.Accept;
                }

                bool isSaved = groupUserRepositoryG.Save();
                return Json(new { ok = true, groupId = id });
            }
            catch (Exception)
            {

                return Json(new { ok = false });
            }
        }
        public IActionResult DeleteRequest(int id)
        {
            try
            {
                var groupuser = groupUserRepositoryG.GetByID(id);
                if (groupuser != null)
                {
                    //groupuser.IsRequest = true;
                    groupuser.StatusRequset = StatusRequset.Reject;
                }

                bool isSaved = groupUserRepositoryG.Save();
                return Json(new { ok = true, groupId = id });
            }
            catch (Exception)
            {

                return Json(new { ok = false });
            }
        }
    }
}
