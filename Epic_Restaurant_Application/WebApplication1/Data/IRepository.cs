

using System.Collections.Generic;

namespace Epic_Restaurant_Food_Orders.Data
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Add(T entity);
        void Edit(T entity);
        void Remove(int id);
    }
}
