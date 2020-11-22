using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;

namespace shopapp.data.Concrete
{
    public class EfCoreGenericRepository<TContext, TEntity> : IRepository<TEntity>
    where TEntity : class
    where TContext : DbContext, new()
    {
        public void create(TEntity c)
        {
            using(var db=new TContext()){
                db.Set<TEntity>().Add(c);
                db.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
             using(var db=new TContext()){
                db.Set<TEntity>().Remove(entity);
                db.SaveChanges();
            }
        }

        public List<TEntity> GetAll()
        {
             using(var db=new TContext()){
               return db.Set<TEntity>().ToList();
            }
        }

        public TEntity GetById(int i)
        {
             using(var db=new TContext()){
                return db.Set<TEntity>().Find(i);
            }
        }

        public void Update(TEntity c)
        {
             using(var db=new TContext()){
               db.Entry(c).State=EntityState.Modified;
               db.SaveChanges();
            }
        }
    }
}