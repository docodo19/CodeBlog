using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MyBlog.Framework;
using MyBlog.Services.Repository;
using MyBlog.Domain.Interface;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        private IHomeService _homeService;
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }


        public ActionResult Index()
        {
            //int hour = DateTime.Now.Hour;
            //ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            string userId = User.Identity.GetUserId();

            var model = _homeService.GetHomeIndexViewModel(userId);

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}