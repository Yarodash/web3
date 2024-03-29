﻿using DAL.Entity;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDbContext db;

        public ArticleRepository(AppDbContext context)
        {
            db = context;
        }

        public IEnumerable<Article> GetAll()
        {
            return db.Articles
                .Include(a => a.Tags)
                .Include(a => a.Category)
                .ToList();
        }

        public Article Get(int id)
        {
            return db.Articles
                .Include(a => a.Tags)
                .Include(a => a.Category)
                .FirstOrDefault(a => a.Id == id);
        }

        public void Create(Article article)
        {
            db.Articles.Add(article);
        }

        public void Update(Article article)
        {
            db.Entry(article).State = EntityState.Modified;
        }

        public IEnumerable<Article> Find(Func<Article, Boolean> predicate)
        {
            return db.Articles
                .Include(a => a.Tags)
                .Include(a => a.Category)
                .Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Article article = db.Articles.Find(id);
            if (article != null)
                db.Articles.Remove(article);
        }
    }
}
