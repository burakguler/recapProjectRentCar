using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IEntityRepository<Type> where Type:class, IEntity,new()
    {
        List<Type> GetAll(Expression<Func<Type, bool>> filter = null);
        Type Get(Expression<Func<Type, bool>> filter);
        void Add(Type entity);
        void Update(Type entity);
        void Delete(Type entity);
    }
}
