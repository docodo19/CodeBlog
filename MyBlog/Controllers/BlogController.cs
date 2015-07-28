using Microsoft.AspNet.Identity;
using MyBlog.Domain.Interface;
using MyBlog.Domain.Models;
using MyBlog.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MyBlog.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private IBlogService _repo;
        public BlogController(IBlogService repo)
        {
            _repo = repo;
        }

        // GET: BlogGroup
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var model = new BlogIndexViewModel();
            model.BlogGroups = _repo.GetBlogGroups(userId);
            return View(model);
        }

        // GET: Create BlogGroup
        [HttpGet]
        public ActionResult CreateBlogGroup()
        {
            var model = _repo.GetBlogCreateBlogGroupViewModel();
            return View(model);
        }

        // POST: Post BloggGroup
        [HttpPost]
        public ActionResult CreateBlogGroup(BlogCreateBlogGroupViewModel model)
        {
            if(ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                _repo.SaveBlogGroup(model, userId);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditBlogGroup(int id)
        {
            var userId = User.Identity.GetUserId();
            var model = _repo.GetBlogEditBlogGroupViewModel(id, userId);
            return View(model);
        }

        
        [HttpPost]
        public ActionResult EditBlogGroup(BlogEditBlogGroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                _repo.SaveEditedBlogGroup(model, userId);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }



        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            var userId = User.Identity.GetUserId();
            var model = _repo.GetBlogGroupDetails(id, userId);


            return View(model);
        }

      

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View();
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            var model = _repo.GetBlogGroup(id, userId);
            return View(model);
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(BlogGroup model)
        {
            var userId = User.Identity.GetUserId();
            _repo.DeleteBlogGroup(model.Id, userId);
            return RedirectToAction("Index");
          
        }


        // GET: Get list of Blogs associated with the BlogGroup
        [HttpGet]
        public ActionResult Blogs(int id)
        {
            var userId = User.Identity.GetUserId();
            var model = _repo.GetBlogs(userId, id);
            return View(model);
        }
        
        // GET: Create Blog
        public ActionResult CreateBlog(int id)
        {
            var model = new Blog();
            model.BlogGroup_Id = id;
            return View(model);
        }

        // POST: Create Blog
        [HttpPost]
        public ActionResult CreateBlog(Blog model)
        {
            _repo.SaveBlog(model);
            return RedirectToAction("Blogs", new { id = model.BlogGroup_Id });
        }

        /// <summary>
        /// Blog Details Section
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult BlogDetails(int id)
        {
            return View(_repo.GetBlog(User.Identity.GetUserId(), id));
        }

        /// <summary>
        /// Edit Blog Section
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditBlog(int id)
        {
            return View(_repo.GetBlog(User.Identity.GetUserId(), id));
        }

        [HttpPost]
        public ActionResult EditBlog(Blog model)
        {
            _repo.SaveBlog(model);
            return RedirectToAction("Blogs", new { id = model.BlogGroup_Id });
        }

        /// <summary>
        /// Delete Blog Section
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteBlog(int id)
        {
            return View(_repo.GetBlog(User.Identity.GetUserId(), id));
        }

        [HttpPost]
        public ActionResult DeleteBlog(Blog model)
        {
            _repo.DeleteBlog(User.Identity.GetUserId(), model.Id);
            return RedirectToAction("Blogs", new { id = model.BlogGroup_Id});
        }
    }
}
