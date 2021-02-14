using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable pattern implementation of c#
            using (NorthwindContext context=new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);   //referansı yakalamak
                addedEntity.State = EntityState.Added;     //bu eklenecek nesne
                context.SaveChanges();                     //ekle

            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);     //referansı yakalamak
                deletedEntity.State = EntityState.Deleted;     //bu eklenecek nesne
                context.SaveChanges();                         //ekle

            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return filter == null
                ? context.Set<Product>().ToList()
                : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void UpDate(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);       //referansı yakalamak
                updatedEntity.State = EntityState.Modified;     //bu eklenecek nesne
                context.SaveChanges();                         //ekle
                 
            }
        }
    }
}
