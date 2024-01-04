using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext db;
        private TagRepository tag_repository;
        private CategoryRepository category_repository;
        private ArticleRepository article_repository;

        public UnitOfWork(DbContextOptions<AppDbContext> options)
        {
            db = new AppDbContext(options);
        }

        public ITagRepository Tags
        {
            get
            {
                tag_repository ??= new TagRepository(db);
                return tag_repository;
            }
        }

        public ICategoryRepository Categories
        {
            get
            {
                category_repository ??= new CategoryRepository(db);
                return category_repository;
            }
        }

        public IArticleRepository Articles
        {
            get
            {
                article_repository ??= new ArticleRepository(db);
                return article_repository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
