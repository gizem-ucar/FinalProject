using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T>
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);   //
        T Get(Expression<Func   <T, bool>> filter);
        void Add(T entity);
        void UpDate(T entity);
        void Delete(T entity);

        List<T> GetAllBycategory(int categoryId);
    }
}
