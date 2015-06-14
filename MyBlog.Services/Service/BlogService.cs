using MyBlog.Domain.Interface;
using MyBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Services.Repository;

namespace MyBlog.Services.Service
{
    public class BlogService : MyBlog.Domain.Interface.IBlogService
    {
        private IGenericRepository _repo;
        public BlogService(IGenericRepository repo)
        {
            _repo = repo;
        }

        //Get all BlogGroups
        public IList<BlogGroup> GetBlogGroups()
        {
            return _repo.Query<BlogGroup>().OrderBy(m => m.GroupName).ToList();
        }

        //Get User's BlogGroups
        public IList<BlogGroup> GetBlogGroups(string userId)
        {
            return _repo.Query<BlogGroup>().Where(b => b.User_Id == userId).OrderBy(m => m.GroupName).ToList();
        }

        //Get all Blogs
        public IList<Blog> GetBlogs()
        {
            return _repo.Query<Blog>().OrderBy(m => m.TimeCreated).ToList();
        }

        //Get User's Blogs
        public IList<Blog> GetBlogs(string userId)
        {
            return _repo.Query<Blog>().Where(b => b.BlogGroup.User_Id == userId).OrderBy(m => m.TimeCreated).ToList();
        }

        //Get all User's Blogs and BlogGroups
        public IList<BlogGroup> GetBlogsAndBlogGroups(string userId)
        {
            return _repo.Query<BlogGroup>().Where(b => b.User_Id == userId).Include(b => b.Blogs).ToList();
        }

        //Get Empty BlogGroup with List of Topics
        public BlogGroup GetEmptyBlogGroupWithTopicList()
        {
            var model = new BlogGroup();
            model.Topics = new List<Topic>();
            model.Topics = _repo.Query<Topic>().OrderBy(t => t.TopicName).ToList();
            return model;
        }

        //Save Blog Group
        public void SaveBlogGroup(BlogGroup model, string userId)
        {
            model.User_Id = userId;
            model.TimeCreated = DateTime.Now;
            model.TimeModified = DateTime.Now;
            _repo.Add<BlogGroup>(model);
            _repo.SaveChanges();
        }


    }
}
