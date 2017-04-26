using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBlogProvider
    {
        void Add(Blog item);
        IEnumerable<Blog> GetAll();
        Blog GetById(int id);
        void Edit(Blog item);
        void DeleteById(int id);
    }
}
