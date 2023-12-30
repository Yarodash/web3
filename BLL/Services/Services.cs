using DAL.Interfaces;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BLL.Services
{
    public class Services
    {
        private readonly DbContextOptions<AppDbContext> options;

        public Services(DbContextOptions<AppDbContext> options)
        {
            this.options = options;
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return new UnitOfWork(options);
        }

        public TagService TagService { 
            get
            {
                return new TagService(GetUnitOfWork());
            }
        }

        public UserService UserService
        {
            get
            {
                return new UserService(GetUnitOfWork());
            }
        }

        public CategoryService CategoryService
        {
            get
            {
                return new CategoryService(GetUnitOfWork());
            }
        }

        public ArticleService ArticleService
        {
            get
            {
                return new ArticleService(GetUnitOfWork());
            }
        }
    }
}
