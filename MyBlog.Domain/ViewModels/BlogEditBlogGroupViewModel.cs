using MyBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.ViewModels
{
    public class BlogEditBlogGroupViewModel
    {
        public BlogGroup BlogGroup { get; set; }
        public List<TopicCheckBox> TopicCheckBoxes { get; set; }

        public BlogEditBlogGroupViewModel()
        {
            this.BlogGroup = new BlogGroup();
            this.BlogGroup.Topics = new List<Topic>();
            this.TopicCheckBoxes = new List<TopicCheckBox>();
        }
    }
}
