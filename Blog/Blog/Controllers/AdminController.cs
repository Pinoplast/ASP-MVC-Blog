using BLL;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helpers;
namespace Blog.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        IBlogProvider blogs = new BlogProvider();
        IPostProvider posts = new PostProvider();
        IImageProvider images = new ImageProvider();
        public ActionResult Index()
        {
            return View("AllBlogs");
        }

        [Authorize(Roles = "admin")]
        public ActionResult AllBlogs()
        {
            var res = blogs.GetAll();
            return View(res);
        }

        [Authorize(Roles = "admin")]
        public ActionResult AddBlog()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult AddNewBlog(string Name)
        {
            blogs.Add(new Helpers.Blog()
            {
                Name = Name
            });

            return RedirectToRoute(new { controller = "Home", action = "AllBlogs" });
        }

        [Authorize(Roles = "admin")]
        public ActionResult EditBlog(int id)
        {
            var res = blogs.GetById(id);
            return View(res);
        }

        [Authorize(Roles = "admin")]
        public ActionResult EditCurrentBlog(int Id, string Name)
        {
            blogs.Edit(new Helpers.Blog()
            {
                Id = Id,
                Name = Name
            });
            return RedirectToRoute(new { controller = "Admin", action = "AllBlogs" });
        }

        [Authorize(Roles = "admin")]
        public ActionResult AddPost(int BlogId)
        {
            var model = new PostModel()
            {
                BlogId = BlogId
            };

            return View(model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult AddNewPost(string Title, string Content, int BlogId, string Image)
        {
            posts.Add(new Helpers.Post()
            {
                BlogId = BlogId,
                Content = Content,
                Title = Title
            }, new Image()
            {
                Img = Image
            });
            return RedirectToRoute(new { controller = "Admin", action = "AllBlogs" });
        }

        [Authorize(Roles = "admin")]
        public ActionResult EditPostPage(int id)
        {
            var post = posts.GetById(id);
            var img = images.GetByOwnerId(post.Id);
            var model = new PostModel()
            {
                Title = post.Title,
                Content = post.Content,
                BlogId = post.BlogId,
                Id = post.Id,
                Image = img.Img
            };
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult EditPost(int Id, string Title, string Content, int BlogId, string Image)
        {
            posts.Edit(new Helpers.Post()
            {
                Id = Id,
                Title = Title,
                BlogId = BlogId,
                Content = Content
            },
            new Image()
            {
                Img = Image
            });

            return RedirectToAction("DetailsAboutBlog", "Admin", new { id = BlogId });
        }

        [Authorize(Roles = "admin")]
        public ActionResult PostDetails(int id)
        {
            var res = posts.GetById(id);
            var resImg = images.GetByOwnerId(res.Id);
            return View("PostDetails", new PostModel()
            {
                Id = res.Id,
                Title = res.Title,
                Content = res.Content,
                BlogId = res.BlogId,
                Image = resImg.Img
            });
        }

        [Authorize(Roles = "admin")]
        public ActionResult DetailsAboutBlog(int id)
        {
            List<Post> postsRes = posts.GetByOwnerId(id).ToList();
            var blog = blogs.GetById(id);

            var res = new PostsModel()
            {
                posts = postsRes,
                blog = blog
            };
            return View(res);
        }


        [Authorize(Roles = "admin")]
        public ActionResult DeleteBlog(int id)
        {
            blogs.DeleteById(id);
            return RedirectToRoute(new { controller = "Admin", action = "AllBlogs" });
        }

        [Authorize(Roles = "admin")]
        public ActionResult DeletePost(int id)
        {
            var postInfo = posts.GetById(id);
            posts.DeleteById(id);

            //List<Post> postsRes = posts.GetByOwnerId(postInfo.BlogId).ToList();
            //var blog = blogs.GetById(postInfo.BlogId);

            //var res = new PostsModel()
            //{
            //    posts = postsRes,
            //    blog = blog
            //};

            //return View("DetailsAboutBlog", res);
            return RedirectToAction("DetailsAboutBlog", "Admin", new { id = postInfo.BlogId });
        }
    }
}