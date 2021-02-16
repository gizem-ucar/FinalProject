using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> :IEntityRepository<TEntity>
        where TEntity: class, IEntity, new()
        where TContext: DbContext, new()   
    {
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);   //referansı yakalamak
                addedEntity.State = EntityState.Added;     //bu eklenecek nesne
                context.SaveChanges();                     //ekle

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);     //referansı yakalamak
                deletedEntity.State = EntityState.Deleted;     //bu eklenecek nesne
                context.SaveChanges();                         //ekle

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void UpDate(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);       //referansı yakalamak
                updatedEntity.State = EntityState.Modified;     //bu eklenecek nesne
                context.SaveChanges();                         //ekle

            }
        }
    }
}
