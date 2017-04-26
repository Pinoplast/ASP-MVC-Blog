using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
namespace DALAzure
{
    public class BlogRepository : IBlogRepository
    {
        BlogContext context = new BlogContext();
        public void Add(Blog item)
        {
            context.Blogs.Add(item);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var i = context.Blogs.Where(x => x.Id == id).FirstOrDefault();

            IQueryable<Post> posts = context.Posts.Where(x => x.BlogId == id);

            DeleteImages(posts.ToList());

            context.Posts.RemoveRange(posts);
            context.Blogs.Remove(i);
            context.SaveChanges();
        }

        void DeleteImages(List<Post> posts)
        {
            for(int i = 0; i < posts.Count(); i++)
            {
                int postId = posts[i].Id;
                var a = context.Images.Where(x => x.PostId == postId).FirstOrDefault();
                context.Images.Remove(a);
            }
            context.SaveChanges();   
        }

        public void Edit(Blog item)
        {
            var i = context.Blogs.Find(item.Id);
            context.Entry(i).CurrentValues.SetValues(item);
            context.SaveChanges();
        }

        public IQueryable<Blog> GetAll()
        {
            return context.Blogs;
        }

        public Blog GetById(int id)
        {
            return context.Blogs.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
