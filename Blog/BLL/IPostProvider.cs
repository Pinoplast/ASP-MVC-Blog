using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPostProvider
    {
        void Add(Post item, Image image);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetByOwnerId(int id);
        Post GetById(int id);
        void Edit(Post item, Image image);
        void DeleteById(int id);
    }
}
