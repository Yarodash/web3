using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entity;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class ArticleService : IArticleService
    {
        IUnitOfWork DataBase { get; set; }

        public ArticleService(IUnitOfWork uow)
        {
            DataBase = uow;
        }  

        public ArticleDTO Get(int id)
        {
            var article = DataBase.Articles.Get(id);

            if (article == null)
            {
                throw new ValidationException("Article not found");
            }

            var articleDto = new ArticleDTO
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                CategoryId = article.CategoryId,
                User = article.User,
                Time = article.Time,
            };

            foreach (var tag in article.Tags)
            {
                articleDto.Tags.Add(tag.Id);
            }

            return articleDto;
        }

        public IEnumerable<ArticleDTO> GetAll()
        {
            List<ArticleDTO> articlesDTO = new List<ArticleDTO>();

            foreach (var article in DataBase.Articles.GetAll())
            {
                var articleDto = new ArticleDTO
                {
                    Id = article.Id,
                    Title = article.Title,
                    Content = article.Content,
                    CategoryId = article.CategoryId,
                    User = article.User,
                    Time = article.Time,
                };

                foreach (var tag in article.Tags)
                {
                    articleDto.Tags.Add(tag.Id);
                }

                articlesDTO.Add(articleDto);
            }

            return articlesDTO;
        }

        public ArticleDTO Create(ArticleDTO item)
        {
            if (string.IsNullOrWhiteSpace(item.Title))
            {
                throw new ValidationException("Article title cannot be empty or whitespace");
            }

            if (string.IsNullOrWhiteSpace(item.Content))
            {
                throw new ValidationException("Article content cannot be empty or whitespace");
            }

            var category = DataBase.Categories.Get(item.CategoryId);

            if (category == null)
            {
                throw new ValidationException("Category not found");
            }

            var article = new Article
            {
                Title = item.Title,
                Content = item.Content,
                CategoryId = item.CategoryId,
                User = item.User,
                Time = DateTime.Now
            };
            
            DataBase.Articles.Create(article);
            UpdateTags(article, item.Tags);
            DataBase.Save();

            return Get(article.Id);
        }

        public ArticleDTO Update(int id, ArticleDTO item)
        {
            var article = DataBase.Articles.Get(id);

            if (article == null)
            {
                throw new ValidationException("Article not found");
            }

            var category = DataBase.Categories.Get(item.CategoryId);

            if (category == null)
            {
                throw new ValidationException("Category not found");
            }

            article.Title = item.Title;
            article.Content = item.Content;
            article.CategoryId = item.CategoryId;
            article.User = item.User;

            DataBase.Articles.Update(article);
            UpdateTags(article, item.Tags);
            DataBase.Save();

            return Get(id);
        }

        private void UpdateTags(Article article, IEnumerable<int> tags)
        {
            article.Tags = article.Tags.Where(tag => tags.Contains(tag.Id)).ToList();

            foreach (var tag in tags) { 
                if (!article.Tags.Select(t => t.Id).Contains(tag))
                {
                    var tagEntity = DataBase.Tags.Get(tag);

                    if (tagEntity == null)
                    {
                        throw new ValidationException("Tag not found");
                    }

                    article.Tags.Add(tagEntity);
                }
            }
        }

        public void Delete(int id)
        {
            DataBase.Articles.Delete(id);
            DataBase.Save();
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
