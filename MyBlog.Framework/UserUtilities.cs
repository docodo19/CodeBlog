using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Security.Principal;
using MyBlog.Data;

namespace MyBlog.Framework
{
    
    public static class UserUtilities
    {
        public static string GetUserFirstName(string userId)
        {
            if (userId == null) return "";
            var db = new ApplicationDbContext();
            var user = db.Users.Find(userId);

            return user.FirstName + " " + user.LastName;   
        }
    }
}
