using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class BlogGroupController : Controller
    {
        // GET: BlogGroup
        public ActionResult Index()
        {
            return View();
        }

        // GET: BlogGroup/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BlogGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogGroup/Create
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

        // GET: BlogGroup/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlogGroup/Edit/5
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

        // GET: BlogGroup/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogGroup/Delete/5
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
