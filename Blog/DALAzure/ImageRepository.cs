using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;

namespace DALAzure
{
    public class ImageRepository : IImageRepository
    {
        BlogContext context = new BlogContext();
        public void Add(Image item)
        {
            context.Images.Add(item);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var i = context.Images.Where(x => x.Id == id).FirstOrDefault();
            context.Images.Remove(i);
            context.SaveChanges();
        }

        public void Edit(Image item)
        {
            var i = context.Images.Find(item.Id);
            context.Entry(i).CurrentValues.SetValues(item);
            context.SaveChanges();
        }

        public IQueryable<Image> GetAll()
        {
            return context.Images;
        }

        public Image GetById(int id)
        {
            return context.Images.Where(x => x.Id == id).FirstOrDefault();
        }

        public Image GetByOwnerId(int id)
        {
            return context.Images.Where(x => x.PostId == id).FirstOrDefault();
        }
    }
}
