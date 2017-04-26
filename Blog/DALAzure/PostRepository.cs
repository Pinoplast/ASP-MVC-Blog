using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
namespace DALAzure
{
    public class PostRepository : IPostRepository
    {
        BlogContext context = new BlogContext();
        public void Add(Post item, Image image)
        {
            int id = context.Posts.Add(item).Id;

            context.Images.Add(new Image()
            {
                Img = image.Img,
                PostId = id
            });
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var p = context.Posts.Where(x => x.Id == id).FirstOrDefault();
            var i = context.Images.Where(x => x.PostId == p.Id).FirstOrDefault();
            context.Images.Remove(i);
            context.Posts.Remove(p);
            context.SaveChanges();
        }

        public void Edit(Post item, Image image)
        {
            int id = item.Id;
            var post = context.Posts.Where(x => x.Id == item.Id).FirstOrDefault();
            context.Entry(post).CurrentValues.SetValues(item);
            var i = context.Images.Where(x => x.PostId == id).FirstOrDefault();
            var img = new Image()
            {
                Img = image.Img,
                PostId = i.PostId
            };
            context.Images.Remove(i);
            context.Images.Add(img);
            context.SaveChanges();
        }

        public IQueryable<Post> GetAll()
        {
            return context.Posts;
        }

        public Post GetById(int id)
        {
            return context.Posts.Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<Post> GetByOwnerId(int id)
        {
            return context.Posts.Where(x => x.BlogId == id);
        }
    }
}
