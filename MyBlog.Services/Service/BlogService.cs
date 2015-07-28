using MyBlog.Domain.Interface;
using MyBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Services.Repository;
using MyBlog.Domain.ViewModels;
using MyBlog.Data;

namespace MyBlog.Services.Service
{
    public class BlogService : MyBlog.Domain.Interface.IBlogService
    {
        private ApplicationDbContext db = new ApplicationDbContext();
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
            return _repo.Query<BlogGroup>().Where(b => b.User_Id == userId && b.IsActive == true).OrderBy(m => m.GroupName).ToList();
        }

        public BlogGroup GetBlogGroup(int id, string userId)
        {
            var model = _repo.Find<BlogGroup>(id);

            if (model.User_Id == userId)
            {
                return model;
            }
            else
            {
                return null;
            }

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

        //Get BlogCreateBlogGroupsViewModel
        public BlogCreateBlogGroupViewModel GetBlogCreateBlogGroupViewModel()
        {
            var model = new BlogCreateBlogGroupViewModel();
            model.BlogGroup.Topics = _repo.Query<Topic>().OrderBy(t => t.TopicName).ToList();

            foreach (var topic in model.BlogGroup.Topics)
            {
                model.TopicCheckBoxes.Add(new TopicCheckBox { TopicName = topic.TopicName, TopicId = topic.Id });
            }
            return model;
        }

        //Get BlogCreateBlogGroupsViewModel used for Edit Blog Groups
        public BlogEditBlogGroupViewModel GetBlogEditBlogGroupViewModel(int id, string userId)
        {

            var model = new BlogEditBlogGroupViewModel();
            model.BlogGroup = _repo.Query<BlogGroup>().Where(b => b.Id == id && b.User.Id == userId).Include(b => b.Topics).FirstOrDefault();

            var topics = _repo.Query<Topic>().OrderBy(t => t.TopicName);

            foreach (var t in topics)
            {
                model.TopicCheckBoxes.Add(new TopicCheckBox { TopicName = t.TopicName, TopicId = t.Id, IsSelected = false });

                foreach (var topic in model.BlogGroup.Topics)
                {
                    if (t.TopicName == topic.TopicName)
                    {
                        //model.TopicCheckBoxes.Add(new TopicCheckBox { TopicName = t.TopicName, TopicId = t.Id, IsSelected = true });
                        model.TopicCheckBoxes.Where(c => c.TopicName == topic.TopicName).FirstOrDefault().IsSelected = true;

                    }
                }
            }

            return model;
        }

        //Save Blog Group
        public void SaveBlogGroup(BlogCreateBlogGroupViewModel model, string userId)
        {
            model.BlogGroup.User_Id = userId;
            model.BlogGroup.TimeCreated = DateTime.Now;
            model.BlogGroup.TimeModified = DateTime.Now;
            model.BlogGroup.Topics = new List<Topic>();

            foreach (var item in model.TopicCheckBoxes)
            {
                if (item.IsSelected == true)
                {
                    var topic = _repo.Query<Topic>().Where(t => t.TopicName == item.TopicName).FirstOrDefault();
                    model.BlogGroup.Topics.Add(topic);
                }
            }
            _repo.Add<BlogGroup>(model.BlogGroup);
            _repo.SaveChanges();
        }

        //Save Edited Blog Group
        public void SaveEditedBlogGroup(BlogEditBlogGroupViewModel model, string userId)
        {
            model.BlogGroup.User_Id = userId;
            model.BlogGroup.TimeCreated = DateTime.Now;
            model.BlogGroup.TimeModified = DateTime.Now;
            model.BlogGroup.Topics = new List<Topic>();

            foreach (var item in model.TopicCheckBoxes)
            {
                if (item.IsSelected == true)
                {
                    var topic = _repo.Query<Topic>().Where(t => t.TopicName == item.TopicName).FirstOrDefault();
                    model.BlogGroup.Topics.Add(topic);
                }
            }

            var original = _repo.Query<BlogGroup>().Where(b => b.User_Id == userId && b.Id == model.BlogGroup.Id).Include(b => b.Topics).FirstOrDefault();

            if (original != null)
            {
                original.GroupName = model.BlogGroup.GroupName;
                original.GroupDescription = model.BlogGroup.GroupDescription;
                original.TimeModified = DateTime.Now;
                original.Topics = model.BlogGroup.Topics;
            }

            _repo.SaveChanges();
        }

        //Get BlogGroup Details
        public BlogGroup GetBlogGroupDetails(int id, string userId)
        {
            var model = new BlogGroup();
            model = _repo.Query<BlogGroup>().Where(b => b.Id == id && b.User.Id == userId).Include(b => b.Topics).FirstOrDefault();
            model.Topics = model.Topics.OrderBy(t => t.TopicName).ToList();
            return model;
        }




        //Delete BlogGroup
        public void DeleteBlogGroup(int id, string userId)
        {
            //db.BlogGroups.Where(b => b.Id == id && b.User_Id == userId).FirstOrDefault().IsActive = false;
            var model = _repo.Find<BlogGroup>(id);
            if (model.User_Id == userId)
            {
                _repo.Find<BlogGroup>(id).IsActive = false;
                _repo.SaveChanges();
            }
        }


        /*
         * Blog Section ----------------------------------------------------------------------------------------------------
         * */

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

        //Get User's Blogs under a specific BlogGroup
        public BlogBlogsViewModel GetBlogs(string userId, int blogGroupId)
        {
            var model = new BlogBlogsViewModel();
            model.BlogGroup = _repo.Find<BlogGroup>(blogGroupId);
            model.Blogs = _repo.Query<Blog>().Where(b => b.BlogGroup.User_Id == userId && b.BlogGroup_Id == blogGroupId && b.IsActive == true).ToList();
            foreach (var blog in model.Blogs)
            {
                if (blog.Message.Length > 50)
                {
                    blog.Message = blog.Message.Substring(0, 50) + "...";
                }
            }
            return model;
        }

        public Blog GetBlog(string userId, int blogId)
        {
            return _repo.Query<Blog>().Where(b => b.BlogGroup.User_Id == userId && b.Id == blogId).FirstOrDefault();
        }

        // save Blog
        public void SaveBlog(Blog model)
        {
            if (model.TimeCreated == null) model.TimeCreated = DateTime.Now;
            model.TimeModified = DateTime.Now;
            _repo.Add<Blog>(model);
            _repo.SaveChanges();
        }

        public void DeleteBlog(string userId, int blogId)
        {
            var original = this.GetBlog(userId, blogId);
            original.IsActive = false;
            _repo.SaveChanges();

        }


    }
}
