using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICarDal
    {  
        void Add(Car car);
        List<Car> GetAll();
        List<Car> GetAllById(int Id);
        void Update(Car car);
        void Delete(Car car);

    }
}
