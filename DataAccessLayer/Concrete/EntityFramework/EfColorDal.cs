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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (DatabaseContext context = new DatabaseContext()) //in this scope objects are created from databasecontext class will be removed by garbage collector after 'using' is done.
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added; //Entity states: Modified, Added, Deleted, Detached, Unchanged
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return filter == null
                    ? context.Set<Color>().ToList()
                    //Means Select * From Products
                    : context.Set<Color>().Where(filter).ToList();
                //if it isn't null then filter with where syntax and add to list.
            }
        }

        public List<Color> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Color entity)
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
