using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Create(T item);
        T Update(int id, T item);
        void Delete(int id);
        void Dispose();
    }
}
