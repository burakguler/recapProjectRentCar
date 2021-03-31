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
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (DatabaseContext context = new DatabaseContext()) //in this scope objects are created from databasecontext class will be removed by garbage collector after 'using' is done.
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added; //Entity states: Modified, Added, Deleted, Detached, Unchanged
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Brand>().ToList()
                    //Means Select * From Products
                    : context.Set<Brand>().Where(filter).ToList();
                //if it isn't null then filter with where syntax and add to list.
            }
        }

        public List<Brand> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand entity)
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
