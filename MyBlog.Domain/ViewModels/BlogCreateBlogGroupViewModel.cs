using MyBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.ViewModels
{
    public class BlogCreateBlogGroupViewModel
    {
        public BlogGroup BlogGroup { get; set; }
        public List<TopicCheckBox> TopicCheckBoxes { get; set; }

        public BlogCreateBlogGroupViewModel()
        {
            this.BlogGroup = new BlogGroup();
            this.BlogGroup.Topics = new List<Topic>();
            TopicCheckBoxes = new List<TopicCheckBox>();
        }
    }
}
