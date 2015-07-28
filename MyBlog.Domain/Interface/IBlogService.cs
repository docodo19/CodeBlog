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
        BlogGroup GetBlogGroup(int id, string userId);

        IList<Blog> GetBlogs();
        IList<Blog> GetBlogs(string userId);
        BlogBlogsViewModel GetBlogs(string userId, int blogGroupId);

        Blog GetBlog(string userId, int blogId);

        IList<BlogGroup> GetBlogsAndBlogGroups(string userId);
        BlogGroup GetEmptyBlogGroupWithTopicList();
        BlogCreateBlogGroupViewModel GetBlogCreateBlogGroupViewModel();
        BlogEditBlogGroupViewModel GetBlogEditBlogGroupViewModel(int id, string userId);
        void SaveBlogGroup(BlogCreateBlogGroupViewModel model, string userId);
        void SaveEditedBlogGroup(BlogEditBlogGroupViewModel model, string userId);
        BlogGroup GetBlogGroupDetails(int id, string userId);
        void DeleteBlogGroup(int id, string userId);

        void SaveBlog(Blog model);
        void DeleteBlog(string userId, int blogId);
    }
}
