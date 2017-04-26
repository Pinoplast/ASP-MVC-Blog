using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALAzure
{
    public interface IPostRepository
    {
        void Add(Post item, Image image);
        IQueryable<Post> GetAll();
        IQueryable<Post> GetByOwnerId(int id);
        Post GetById(int id);
        void Edit(Post item, Image image);
        void DeleteById(int id);
    }
}
