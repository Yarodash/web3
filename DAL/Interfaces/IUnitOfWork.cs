using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITagRepository Tags { get; }
        ICategoryRepository Categories { get; }
        IArticleRepository Articles { get; }
        void Save();
    }
}
