using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Dispose();
    }
}
