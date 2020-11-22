using System.Collections.Generic;

namespace shopapp.data.Abstract
{
    public interface IRepository<T>
    {
         T GetById(int i);

         List<T> GetAll();

         void create(T c);

         void Update(T c);

         void Delete(T entity);
    }
}