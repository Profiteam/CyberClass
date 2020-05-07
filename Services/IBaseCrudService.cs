using System;
using System.Linq;

namespace Services
{
    public interface IBaseCrudService<T>
    {
        IQueryable<T> GetAll();
        T Get(long id);
        void Create(T item);
        T CreateEntity(T item);
        void Update(T item);
        void Delete(T item);
        void Delete(long id);
    }
}