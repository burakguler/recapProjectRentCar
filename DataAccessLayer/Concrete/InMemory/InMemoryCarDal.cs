using DataAccessLayer.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private readonly List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            {
                new Car { Id = 1, BrandId = 1, ColorId = 1, Description = "Fiat EGEA", ModelYear = "2020", DailyPrice = 150, WeeklyPrice = 900, MonthlyPrice = 3200      },
                new Car { Id = 2, BrandId = 2, ColorId = 2, Description = "BMW 320i", ModelYear = "2015", DailyPrice = 200, WeeklyPrice = 1200, MonthlyPrice = 4000      },
                new Car { Id = 3, BrandId = 3, ColorId = 1, Description = "Mercedes C100", ModelYear = "2017", DailyPrice = 400, WeeklyPrice = 1500, MonthlyPrice = 6500 }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }
       
        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();   
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.WeeklyPrice = car.WeeklyPrice;
            carToUpdate.MonthlyPrice = car.MonthlyPrice;   
        }
        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
        }

    }
}
