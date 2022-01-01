using BlogTask.Models;
using BlogTask.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTask.Controllers
{
  
    public class BlogController : Controller
    {
        IBlogRepository blogRepository;
        public BlogController(IBlogRepository _blogRepository)
        {
            blogRepository = _blogRepository;
        }
        public IActionResult Index()
        {
            
            return View(blogRepository.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                blogRepository.Add(blog);
                blogRepository.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var blog = blogRepository.GetByID(id);
            if(blog != null)
            {
                return View(blog);

            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                blogRepository.Update(blog);
                blogRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(blog);

        }

        public IActionResult Details(int id)
        {
            var blog = blogRepository.GetByID(id);
            if(blog != null)
            {
                return View(blog);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
         {
            var blog = blogRepository.GetByID(id);
            if (blog != null)
            {
                blogRepository.Delete(id);
                blogRepository.Save();
                return Json("");
            }
            return RedirectToAction(nameof(Index));
        }
      
    }
}
