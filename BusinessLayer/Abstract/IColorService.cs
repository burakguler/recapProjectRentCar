using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IColorService
    {
        void Add(Color color);
        List<Color> GetAll();
        List<Color> GetNameById(int Id);
        void Update(Color color);
        void Delete(Color color);
    }
}
