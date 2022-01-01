using AutoMapper;
using BlogTask.Models;
using BlogTask.Models.ViewModel;
using BlogTask.Repository;
using BlogTaskDB.DAL.Repository.ClassRepo;
using BlogTaskDB.DAL.Repository.InterfaceRepo;
using BlogTaskDB.DAL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlogTaskDB.DAL.Paginattion;

namespace BlogTask.Controllers
{
    public class GroupController : Controller
    {
        IGroupReository groupReository;
        IGroupUserRepository groupUserRepository;
        IPostRepository postRepository;
        // using Genric Repository
        IGroupReositoryG groupReositoryG;
        IGroupUserRepositoryG groupUserRepositoryG;
        IPostRepositoryG PostRepositoryG;
        IMapper mapper;
        public GroupController(IGroupReositoryG _groupReositoryG, IGroupUserRepositoryG _groupUserRepositoryG, IPostRepositoryG _PostRepositoryG, IGroupReository _groupReository,IGroupUserRepository _groupUserRepository,IPostRepository _postRepository , IMapper _mapper)
        {
            groupReository = _groupReository;
            groupUserRepository = _groupUserRepository;
            postRepository = _postRepository;

            #region using Genric Repository
            groupReositoryG = _groupReositoryG;
            groupUserRepositoryG = _groupUserRepositoryG;
            PostRepositoryG = _PostRepositoryG;
            #endregion
            mapper = _mapper;
        }
       

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAll( int id=1)
        {

            //return PartialView("_GetAllGroups",groupReository.GetAll());
            //var groups = groupReositoryG.GetAll(1, 2);
            //var groups = groupReository.GetAll(1, 2);

            //var groupsVM = mapper.Map<List<Group>, List<GroupVM>>( groups);
            //var groups = await PaginatedList<Group>.CreateAsync(groupReository.GetAllQU(), id, 2);
            var groups = await PaginatedList<Group>.CreateAsync(groupReositoryG.GetAllAsQueryable(), id, 2);

            //Using Generic Repository 
            return PartialView("_GetAllGroups", groups);

        } 
        public IActionResult Create()
        {
            return PartialView("_CreateGroup_PV");
        }
        [HttpPost]
        public IActionResult Create(GroupVM groupVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var group = mapper.Map<Group>(groupVM);
                    //groupReository.Add(group);
                    // Use Generic Repository 
                    groupReositoryG.Add(group);
                    var ISSaved = groupReositoryG.Save();
                    return Json(new { ok = ISSaved });
                }
                //return Json(new { ok = false });
                return PartialView("_CreateGroup_PV", groupVM);
                
            }
            catch (Exception)
            {

                return Json(new { ok = false });
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                var group = groupReositoryG.GetByID(id);
                var groupVM = mapper.Map<GroupVM>(group);

                return PartialView("_EditGroup", groupVM);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult Edit(GroupVM groupVM)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    //groupReository.Update(group);
                    var group= mapper.Map<Group>(groupVM);
                    groupReositoryG.Update(group);
                    bool IsSaved = groupReositoryG.Save();
                    return Json(new { ok = IsSaved });
                }
                return Json(new { ok = false });
            }
            catch (Exception)
            {

                return Json(new { ok = false });
            }
        }

        public IActionResult Details(int id)
        {
            var group = groupReositoryG.GetByID(id);
            var groupVM = mapper.Map<GroupVM>(group);
            return PartialView("_DetailsGroup",groupVM);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                 var group = groupReositoryG.GetByID(id);

                groupReositoryG.Remove(group);
                bool IsSaved = groupReositoryG.Save();
                return Json(new { ok = IsSaved });
            }
            catch (Exception)
            {

                return Json(new { ok = false });
            }
        }

        public IActionResult GetAllGroupsSuggestions()
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                //var groups = groupReository.GetGroupsSuggestion(userId);
                
                var groups = groupReositoryG.GetGroupsSuggestion(userId);
                var groupsVM = mapper.Map<List<Group>,List<GroupVM>>(groups);
                return PartialView("_GetAllGroupsSuggestions", groupsVM);
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public IActionResult GetAllGroupsForUser()
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                //var groups = groupReository.GetAllGroupsForuser(userId);
                var groups = groupReositoryG.GetAllGroupsForuser(userId);
                var groupsVM = mapper.Map<List<Group>, List<GroupVM>>(groups);
                return PartialView("_GetAllGroupsForUser", groupsVM);
            }
            catch (Exception)
            {

                return PartialView();
            }
        }

        public IActionResult GetPendingGroups()
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                //var pendingGroups = groupReository.GetPendingGroups(userId);
                var pendingGroups = groupReositoryG.GetPendingGroups(userId);
                var groupsVM = mapper.Map<List<Group>, List<GroupVM>>(pendingGroups);
                return PartialView("_GetPendingGroups", groupsVM);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #region Move to GroupUserController
        //public IActionResult GetJoinRequest(int id)
        //{
        //    try
        //    {
        //        var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        var groupUser = new GroupUser()
        //        {
        //            GroupID = id,
        //            UserId = userId,
        //            //IsRequest = false
        //            StatusRequset = StatusRequset.Pending,
        //            Date = DateTime.Now
        //        };
        //        //groupUserRepository.Add(groupUser);
        //        groupUserRepositoryG.Add(groupUser);
        //        var isSaved = groupUserRepositoryG.Save();
        //        return Json(new { ok = isSaved });
        //    }
        //    catch (Exception)
        //    {

        //        return Json(new { ok = false });
        //    }
        //}

        //public IActionResult GetRequestsGroup(int id)
        //{
        //    //var groupUserRequest = groupUserRepository.GetListGroupUsers(id);
        //    var groupUserRequest = groupUserRepositoryG.GetListGroupUsers(id);

        //    return PartialView("_GetRequestsGroup", groupUserRequest);

        //}
        //public IActionResult ConfirmRequest(int id)
        //{

        //    try
        //    {

        //        var groupuser = groupUserRepository.GetByID(id);
        //        if(groupuser != null)
        //        {
        //            //groupuser.IsRequest = true;
        //            groupuser.StatusRequset = StatusRequset.Accept;
        //        }

        //        bool isSaved = groupUserRepository.Save();
        //        return Json(new { ok = true,groupId = id });
        //    }
        //    catch (Exception)
        //    {

        //        return Json(new { ok = false });
        //    }
        //}
        //public IActionResult DeleteRequest(int id)
        //{
        //    try
        //    {
        //        var groupuser = groupUserRepository.GetByID(id);
        //        if (groupuser != null)
        //        {
        //            //groupuser.IsRequest = true;
        //            groupuser.StatusRequset = StatusRequset.Reject;
        //        }

        //        bool isSaved = groupUserRepository.Save();
        //        return Json(new { ok = true, groupId = id });
        //    }
        //    catch (Exception)
        //    {

        //        return Json(new { ok = false });
        //    }
        //}

        #endregion

        //public IActionResult GetGroup(int id)
        //{

        //    try
        //    {
        //        int NumberOfUser = groupUserRepository.GetNumbersOfUserInGroup(id);
        //        var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        //var posts = postRepository.GetPublicPosts(userId).Select(p => new PostInGroupVM(p));
        //        //ViewBag.userId = userId;
        //        var posts = postRepository.GetAllPostsInGroup(id).Select(p => new PostInGroupVM(p) { CurrentUserId = userId,NumberOfUserInGroup= NumberOfUser }).ToList();
        //        return View(posts);

        //    }
        //    catch (Exception)
        //    {

        //        return PartialView();
        //    }
        //}

        public IActionResult GetGroup(int id)
        {

            try
            {
                ViewBag.GroupID = id; 
                return View();

            }
            catch (Exception)
            {

                return View();
            }
        }
        public IActionResult GetDataGroup(int id)
        {
            try
            {
                //int NumberOfUser = groupUserRepository.GetNumbersOfUserInGroup(id);
                int NumberOfUser = groupUserRepositoryG.GetNumbersOfUserInGroup(id);
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                //var group = postRepository.GetAllPostsInGroup(id).Select(p => new GroupHeaderVM(p) { CurrentUserId = userId, NumberOfUserInGroup = NumberOfUser }).FirstOrDefault();
                var group = PostRepositoryG.GetAllPostsInGroup(id).Select(p => new GroupHeaderVM(p) { CurrentUserId = userId, NumberOfUserInGroup = NumberOfUser }).FirstOrDefault();
                return PartialView("_GroupDataHeader", group);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Move this Action TO PostCOntroller
        public IActionResult GetPostsInGroup(int id)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                //var PostsInGroup = postRepository.GetAllPostsInGroup(id).Select(p => new PostInGroupVM(p) { CurrentUserId = userId}).ToList();
                var PostsInGroup = PostRepositoryG.GetAllPostsInGroup(id).Select(p => new PostInGroupVM(p) { CurrentUserId = userId}).ToList();

                return PartialView("_GetPostsInGroup", PostsInGroup);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    
}
