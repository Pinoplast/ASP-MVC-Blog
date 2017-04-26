using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALAzure
{
    public interface IBlogRepository
    {
        void Add(Blog item);
        IQueryable<Blog> GetAll();
        Blog GetById(int id);
        void Edit(Blog item);
        void DeleteById(int id);
    }
}
