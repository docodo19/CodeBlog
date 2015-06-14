using MyBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.ViewModels
{
    public class BlogIndexViewModel
    {
        public IList<BlogGroup> BlogGroups { get; set; }
        public BlogGroup BlogGroup { get; set; }
        public BlogIndexViewModel()
        {
            this.BlogGroup = new BlogGroup();
            this.BlogGroups = new List<BlogGroup>();
        }
        
    }
}
