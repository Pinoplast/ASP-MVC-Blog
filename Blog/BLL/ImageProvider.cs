using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using DALAzure;

namespace BLL
{
    public class ImageProvider : IImageProvider
    {
        IImageRepository repository = new ImageRepository();
        public void Add(Image item)
        {
            repository.Add(item);
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }

        public void Edit(Image item)
        {
            repository.Edit(item);
        }

        public IEnumerable<Image> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public Image GetById(int id)
        {
            return repository.GetById(id);
        }

        public Image GetByOwnerId(int id)
        {
            return repository.GetByOwnerId(id);
        }
    }
}
