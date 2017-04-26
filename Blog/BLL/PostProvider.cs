using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using DALAzure;

namespace BLL
{
    public class PostProvider : IPostProvider
    {
        IPostRepository repository = new PostRepository();
        public void Add(Post item, Image image)
        {
            repository.Add(item, image);
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }

        public void Edit(Post item, Image image)
        {
            repository.Edit(item, image);
        }

        public IEnumerable<Post> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public Post GetById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<Post> GetByOwnerId(int id)
        {
            return repository.GetByOwnerId(id).ToList();
        }
    }
}
