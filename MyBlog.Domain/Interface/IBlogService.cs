using MyBlog.Domain.Models;
using MyBlog.Domain.ViewModels;
using System;
using System.Collections.Generic;
namespace MyBlog.Domain.Interface
{
    public interface IBlogService
    {
        IList<BlogGroup> GetBlogGroups();
        IList<BlogGroup> GetBlogGroups(string userId);
        IList<Blog> GetBlogs();
        IList<Blog> GetBlogs(string userId);
        IList<BlogGroup> GetBlogsAndBlogGroups(string userId);
        BlogGroup GetEmptyBlogGroupWithTopicList();
        BlogCreateBlogGroupViewModel GetBlogCreateBlogGroupViewModel();
        void SaveBlogGroup(BlogCreateBlogGroupViewModel model, string userId);
    }
}
