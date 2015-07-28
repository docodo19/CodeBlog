using MyBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.ViewModels
{
    public class BlogBlogsViewModel
    {
        public BlogGroup BlogGroup { get; set; }
        public IList<Blog> Blogs { get; set; }
        public Blog Blog { get; set; }

        public BlogBlogsViewModel()
        {
            BlogGroup = new BlogGroup();
            Blogs = new List<Blog>();
            Blog = new Blog();
        }

    }
}
