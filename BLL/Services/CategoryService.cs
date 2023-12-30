﻿using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entity;
using DAL.Interfaces;
using System.Collections.Generic;

namespace BLL.Services
{
    public class CategoryService : ICategoryService
    {
        IUnitOfWork DataBase { get; set; }

        public CategoryService(IUnitOfWork uow)
        {
            DataBase = uow;
        }

        public IEnumerable<ArticleDTO> GetNews(int id)
        {
            var articles = DataBase.Categories.Get(id).Articles;

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(articles);
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            var categories = DataBase.Categories.GetAll();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(categories);
        }

        public CategoryDTO Get(int id)
        {
            var category = DataBase.Categories.Get(id);

            if (category == null)
            {
                throw new ValidationException("Category not found", "");
            }

            return new CategoryDTO { Id = category.Id, Name = category.Name };
        }

        public void Create(CategoryDTO item)
        {
            if (string.IsNullOrWhiteSpace(item.Name))
            {
                throw new ValidationException("Category name cannot be empty or whitespace", "");
            }

            DataBase.Categories.Create(new Category { Name = item.Name });
            DataBase.Save();
        }

        public void Update(CategoryDTO item)
        {
            var category = DataBase.Categories.Get(item.Id);

            if (category == null)
            {
                throw new ValidationException("Category not found", "");
            }

            category.Name = item.Name;
            DataBase.Categories.Update(category);
            DataBase.Save();
        }

        public void Delete(int id)
        {
            DataBase.Categories.Delete(id);
            DataBase.Save();
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}