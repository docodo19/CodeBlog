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
            var model = _repo.GetEmptyBlogGroupWithTopicList();
            return View(model);
        }

        // POST: Post BloggGroup
        [HttpPost]
        public ActionResult CreateBlogGroup(BlogGroup model)
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



        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
            return View();
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
