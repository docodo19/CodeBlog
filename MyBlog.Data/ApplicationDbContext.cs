using Microsoft.AspNet.Identity.EntityFramework;
using MyBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public IDbSet<Blog> Blogs { get; set; }
        public IDbSet<BlogGroup> BlogGroups { get; set; }
        public IDbSet<Topic> Topics { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
