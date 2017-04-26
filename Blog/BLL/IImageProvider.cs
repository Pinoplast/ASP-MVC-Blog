using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IImageProvider
    {
        void Add(Image item);
        IEnumerable<Image> GetAll();
        Image GetById(int id);
        Image GetByOwnerId(int id);
        void Edit(Image item);
        void DeleteById(int id);
    }
}
