using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    // sınırlandırdık
    // T sadece class ve IEntitiy üyesi olabilir
    //IEntity interface olduğundna new lenemez yani sadece ona bağlı olan classlar gelebilir.
   public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter=null);

        T Get(Expression<Func<T,bool>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
