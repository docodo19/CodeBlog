namespace MyBlog.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using MyBlog.Domain.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MyBlog.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyBlog.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //Seeder Setting (Change to True once seeded)
            bool seedUser = true;


            if (seedUser) UserSeeder(context);


        }

        private void UserSeeder(ApplicationDbContext db)
        {
            var store = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(store);
            var roleStore = new RoleStore<IdentityRole>(db);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            //Create different types of roles
            if (!roleManager.RoleExists("Admin")) roleManager.Create(new IdentityRole { Name = "Admin" });
            if (!roleManager.RoleExists("User")) roleManager.Create(new IdentityRole { Name = "User" });

            //Seed User as "Admin"
            if (!db.Users.Any(u => u.UserName == "docodo19@gmail.com"))
            {
                //Create ApplicationUser Object
                var user = new ApplicationUser()
                {
                    FirstName = "Dan",
                    LastName = "Do",
                    UserName = "docodo19@gmail.com",
                    Email = "docodo19@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "2067659109",
                    BlogGroups = new List<BlogGroup>
                    {
                        new BlogGroup {
                            TimeCreated = DateTime.Now,
                            TimeModified = DateTime.Now,
                            GroupName = "My ASP.NET Learning Experience 1",
                            GroupDescription = "Blog about how I learned APS.NET 1",
                            Blogs = new List<Blog> {
                                new Blog { Subject = "docodo19: Test Subject 1", Message = "docodo19: Test Message 1", TimeCreated = DateTime.Now , TimeModified = DateTime.Now},
                                new Blog { Subject = "docodo19: Test Subject 2", Message = "docodo19: Test Message 2", TimeCreated = DateTime.Now , TimeModified = DateTime.Now},
                                new Blog { Subject = "docodo19: Test Subject 3", Message = "docodo19: Test Message 3", TimeCreated = DateTime.Now , TimeModified = DateTime.Now}
                            },
                            Topics = new List<Topic> {
                                new Topic { TimeCreated = DateTime.Now, TimeModified = DateTime.Now, TopicName = "ASP.NET", IsSpecific = true },
                                new Topic { TimeCreated = DateTime.Now, TimeModified = DateTime.Now, TopicName = "MVC5", IsSpecific = true },
                                new Topic { TimeCreated = DateTime.Now, TimeModified = DateTime.Now, TopicName = "Razor", IsSpecific = true },
                                new Topic { TimeCreated = DateTime.Now, TimeModified = DateTime.Now, TopicName = "HTML", IsSpecific = true },
                                new Topic { TimeCreated = DateTime.Now, TimeModified = DateTime.Now, TopicName = "CSS", IsSpecific = true },
                                new Topic { TimeCreated = DateTime.Now, TimeModified = DateTime.Now, TopicName = "Bootstrap", IsSpecific = true },
                                new Topic { TimeCreated = DateTime.Now, TimeModified = DateTime.Now, TopicName = "Programming", IsSpecific = false },
                                new Topic { TimeCreated = DateTime.Now, TimeModified = DateTime.Now, TopicName = "Web Development", IsSpecific = false },
                            },
                        }
                    }
                   
                };
                //Create an actual user by passing the ApplicationUser Object into userManager
                userManager.Create(user, "123123");
                //Give user a role once user has been created and the user.Id is available
                userManager.AddToRole(user.Id, "Admin");
            }



            if (!db.Users.Any(u => u.UserName == "dhdo19@gmail.com"))
            {
                var user = new ApplicationUser()
                {
                    FirstName = "Daniel",
                    LastName = "Do",
                    UserName = "dhdo19@gmail.com",
                    Email = "dhdo19@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "2067659109",
                    BlogGroups = new List<BlogGroup>
                    {
                        new BlogGroup {
                            TimeCreated = DateTime.Now,
                            TimeModified = DateTime.Now,
                            GroupName = "Let's Learn JavaScript",
                            GroupDescription = "My JavaScript Learning Experience",
                            Blogs = new List<Blog> {
                                new Blog { Subject = "dhdo19: Test Subject 1", Message = "dhdo19: Test Message 1", TimeCreated = DateTime.Now , TimeModified = DateTime.Now},
                                new Blog { Subject = "dhdo19: Test Subject 2", Message = "dhdo19: Test Message 2", TimeCreated = DateTime.Now , TimeModified = DateTime.Now},
                                new Blog { Subject = "dhdo19: Test Subject 3", Message = "dhdo19: Test Message 3", TimeCreated = DateTime.Now , TimeModified = DateTime.Now}
                            },
                            Topics = new List<Topic> {
                                new Topic { TimeCreated = DateTime.Now, TimeModified = DateTime.Now, TopicName = "JavaScript", IsSpecific = true },
                                new Topic { TimeCreated = DateTime.Now, TimeModified = DateTime.Now, TopicName = "AngularJS", IsSpecific = true },
                                new Topic { TimeCreated = DateTime.Now, TimeModified = DateTime.Now, TopicName = "NodeJS", IsSpecific = true },
                            },
                        }
                    }

                };
                //Create an actual user by passing the ApplicationUser Object into userManager
                userManager.Create(user, "123123");
                //Give user a role once user has been created and the user.Id is available
                userManager.AddToRole(user.Id, "User");
            }

        }
    }
}
