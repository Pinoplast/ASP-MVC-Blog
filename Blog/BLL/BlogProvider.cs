using DALAzure;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BlogProvider : IBlogProvider
    {
        IBlogRepository repository = new BlogRepository();
        public void Add(Blog item)
        {
            repository.Add(item);
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }

        public void Edit(Blog item)
        {
            repository.Edit(item);
        }

        public IEnumerable<Blog> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public Blog GetById(int id)
        {
            return repository.GetById(id);
        }
    }
}
