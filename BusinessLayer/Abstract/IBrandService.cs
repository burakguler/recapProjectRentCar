using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBrandService
    {
        void Add(Brand brand);
        List<Brand> GetAll();
        List<Brand> GetNameById(int Id);
        void Update(Brand brand);
        void Delete(Brand brand);
    }
}
