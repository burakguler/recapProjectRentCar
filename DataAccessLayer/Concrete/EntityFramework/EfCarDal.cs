using DataAccessLayer.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (DatabaseContext context = new DatabaseContext()) //in this scope objects are created from databasecontext class will be removed by garbage collector after 'using' is done.
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added; //Entity states: Modified, Added, Deleted, Detached, Unchanged
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    //Means Select * From Products
                    : context.Set<Car>().Where(filter).ToList();
                //if it isn't null then filter with where syntax and add to list.
            }
        }

        public void Update(Car entity)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
