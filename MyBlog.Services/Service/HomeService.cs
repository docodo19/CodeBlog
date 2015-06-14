using MyBlog.Data;
using MyBlog.Domain.Interface;
using MyBlog.Domain.ViewModels;
using MyBlog.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.Service
{
    public class HomeService : IHomeService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public HomeIndexViewModel GetHomeIndexViewModel(string userId)
        {
            var hour = DateTime.Now.Hour;
            var model = new HomeIndexViewModel();
            model.FullName = UserUtilities.GetUserFirstName(userId);
            model.Greeting = hour < 12 ? "Good Morning " + model.FullName : "Good Afternoon " + model.FullName;

            return model;
        }


    }
}
