using BlogTask.Models;
using BlogTask.Models.ViewModel;
using BlogTask.Repository;
using BlogTaskDB.DAL.Paginattion;
using BlogTaskDB.DAL.Repository.InterfaceRepo;
using BlogTaskDB.DAL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogTask.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        IPostRepository postRepository;
        IBlogRepository blogRepository;
        IGroupReository groupReository;

        //Using Generics Repository
        IPostRepositoryG PostRepositoryG;
        IGroupUserRepositoryG groupUserRepositoryG;
        IWebHostEnvironment webHostEnvironment;
        public PostController(IWebHostEnvironment _webHostEnvironment,IGroupUserRepositoryG _groupUserRepositoryG,  IPostRepositoryG _PostRepositoryG, IPostRepository _postRepository,IBlogRepository _blogRepository,IGroupReository _groupReository)
        {
            postRepository = _postRepository;
            blogRepository = _blogRepository;
            groupReository = _groupReository;

            //Using Generics Repo
            PostRepositoryG = _PostRepositoryG;
            webHostEnvironment = _webHostEnvironment;
            groupUserRepositoryG = _groupUserRepositoryG;
        }
       
        public IActionResult Index()
        {
            
            return View();
        }
        #region Befor Using PaginationList
        //public IActionResult GetAllPublicPosts(int id =1)
        //{
        //    try
        //    {
        //        #region Try Using Search
        //        // I use this condition for try Search Method.
        //        //if (!string.IsNullOrEmpty(id))
        //        //{
        //        //    var postsForUser = postRepository.GetPostsForUserByEmail(id).Select(p => new PostVM(p) { Email = p.IdentityUser.Email });

        //        //    return PartialView(postsForUser);
        //        //} 
        //        #endregion

        //        var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        var posts = postRepository.GetPublicPosts(userId).Select(p => new PostVM(p) { Email = p.IdentityUser.Email });
        //        ViewBag.userId = userId;
        //        return PartialView(posts);
        //    }
        //    catch (Exception)
        //    {

        //        return PartialView();
        //    }

        //} 
        #endregion
        public async Task<IActionResult> GetAllPublicPosts(int id = 1)
        {
            try
            {


                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var posts = await PaginatedList<Post>.CreateAsync(PostRepositoryG.GetAllAsQueryable(), id, 3);
                ViewBag.userId = userId;
                return PartialView(posts);
            }
            catch (Exception)
            {

                return PartialView();
            }

        }
        public IActionResult Create()
        {
            var blogs = blogRepository.GetAll();
            ViewBag.BlogID = new SelectList(blogs, "BlogId", "Name");
            //return View();
            return PartialView("_Create");
        }
        [HttpPost]
        public JsonResult Create(Post post,IFormFile img )
        {
            try
            {
                string folderPath = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                string fileName = Guid.NewGuid().ToString() + "." + img.FileName.Split(".")[1];
                string filePath = Path.Combine(folderPath, fileName);
                img.CopyTo(new FileStream(filePath, FileMode.Create));
                post.Img = fileName;
                if (ModelState.IsValid)
                {
                   
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    post.UserId = userId;
                    post.Date = DateTime.Now;
                    //postRepository.Add(post, userId);
                    PostRepositoryG.Add(post);
                    bool isSaved = PostRepositoryG.Save();

                    return Json(new { ok = isSaved });
                }
                return Json(new { ok = false });
            }
            catch (Exception)
            {

                return Json(new { ok = false });
            }
        }

        public IActionResult CreatePostInGroup(int id)
        {
            try
            {
                //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var blogs = blogRepository.GetAll();
                ViewBag.BlogID = new SelectList(blogs, "BlogId", "Name");
                ViewBag.GroupID = id;
                return PartialView("_CreatePostInGroup");
            }
            catch (Exception)
            {

                throw;
            }

        }
        public IActionResult Edit(int id)
        {
            var post = postRepository.GetByID(id);
            var blogs = blogRepository.GetAll();
            ViewBag.BlogID = new SelectList(blogs, "BlogId", "Name",post.BlogID);
            //return View(post);
            return PartialView("_Edit", post);
        }
        [HttpPost]
       public IActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                postRepository.Update(post);
                bool IsSaved = postRepository.Save();
                
                return Json(new { ok = IsSaved });
            }
            return Json(new { ok = false });
        }
        public IActionResult Details(int id)
        {
            var post = postRepository.GetByID(id);
            return PartialView(post);
        }

        public IActionResult Delete(int id)
        {
            postRepository.Delete(id);
            bool IsSaved = postRepository.Save();
            if (IsSaved == false) return Json(new { ok = false });
            else return Json(new { ok = true });
        }

        public async Task< IActionResult> GetAllPostsInGroup(int id)
        {
            
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                //var posts = postRepository.GetPublicPosts(userId).Select(p => new PostInGroupVM(p));
                //ViewBag.userId = userId;
                //var posts = postRepository.GetAllPostsInGroup(id).Select(p => new PostInGroupVM(p) { CurrentUserId = userId});
                var posts = await PaginatedList<Post>.CreateAsync(PostRepositoryG.GetAllPostsInGroupAsQueryAble(id), id, 3);
                return PartialView("GetAllPublicPosts", posts);
                //return View(posts);
                //return PartialView("GetAll", posts);
            }
            catch (Exception)
            {

                return PartialView();
            }
        }

        public IActionResult GetSearchForm(int id)
        {
            var users = groupUserRepositoryG.GetUsers(id);
            ViewBag.Users = new SelectList(users, "Id", "Email");
            ViewBag.groupId = id;
            return PartialView("_GetSearchForm");
        }

        #region Get Search Data 
        //public IActionResult GetSearchData(string  id)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(id))
        //        {
        //            var posts = postRepository.GetPostsForUserByEmail(id).Select(p=> new PostVM(p) {Email = p.IdentityUser.Email });
        //            return PartialView("GetAllPublicPosts", posts);
        //        }
        //        var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        var Publicposts = postRepository.GetPublicPosts(userId).Select(p => new PostVM(p) { Email = p.IdentityUser.Email });
        //        ViewBag.userId = userId;

        //        return PartialView("GetAllPublicPosts", Publicposts);
        //    }
        //    catch (Exception)
        //    {

        //        return PartialView("Error");
        //    }
        //} 
        #endregion

        public async Task<IActionResult> GetDataSearch(int pageindex, SearchDataVM filter)
        {

            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.CurrentUserId = userId;
               
                var posts = PostRepositoryG.SearchGRoup(filter);
                 var postsPaginted=  await PaginatedList<Post>.CreateAsync(posts, pageindex, 2);
                //return PartialView("_GetPostsInGroup", postsPaginted);
                return PartialView("_GetPostsInGroupBySearch", postsPaginted);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public async Task<IActionResult> GetPostsInGroup(int id,int pageIndex)
        //{
        //    try
        //    {
                
        //        var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        ViewBag.CurrentUserId = userId;
        //        var posts = await PaginatedList<Post>.CreateAsync(PostRepositoryG.GetAllPostsInGroupAsQueryAble(id), pageIndex, 2);
        //        return PartialView("_GetPostsInGroup", posts);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        public async Task<IActionResult> GetPostsInGroup(int id, int pageIndex,SearchDataVM filter)
        {
            try
            {

                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.CurrentUserId = userId;
                if(filter.SearchText != null || filter.StartDate != null || filter.SelectedIds != null)
                {
                    var postsBySearch = PostRepositoryG.SearchGRoup(filter);
                    var postsPaginted = await PaginatedList<Post>.CreateAsync(postsBySearch, pageIndex, 2);
                    return PartialView("_GetPostsInGroup", postsPaginted);
                }
                var posts = await PaginatedList<Post>.CreateAsync(PostRepositoryG.GetAllPostsInGroupAsQueryAble(id), pageIndex, 2);
                return PartialView("_GetPostsInGroup", posts);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    
}
