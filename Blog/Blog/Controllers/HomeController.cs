using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helpers;
using Blog.Models;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        IBlogProvider blogs = new BlogProvider();
        IPostProvider posts = new PostProvider();
        IImageProvider images = new ImageProvider();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AllBlogs()
        {
            var res = blogs.GetAll();
            return View(res);
        }
        
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
        
        public ActionResult PostDetails(int id)
        {
            var res = posts.GetById(id);
            var resImg = images.GetByOwnerId(res.Id);
            return View("PostDetails", new PostModel()
            {
                Title = res.Title,
                Content = res.Content,
                BlogId = res.BlogId,
                Image = resImg.Img
            });
        }
    }
}