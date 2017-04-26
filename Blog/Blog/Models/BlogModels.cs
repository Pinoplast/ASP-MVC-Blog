using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public string Image { get; set; }
    }
    public class PostsModel
    {
        public List<Post> posts { get; set; }
        public Helpers.Blog blog { get; set; }
    }
}