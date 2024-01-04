using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entity;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
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

        public void Create(ArticleDTO item)
        {
            if (string.IsNullOrWhiteSpace(item.Title))
            {
                throw new ValidationException("Article title cannot be empty or whitespace", "");
            }

            if (string.IsNullOrWhiteSpace(item.Content))
            {
                throw new ValidationException("Article content cannot be empty or whitespace", "");
            }

            DataBase.Articles.Create(new Article {
                Title = item.Title,
                Content = item.Content,
                CategoryId = item.Category.Id,
                User = item.User,
                Time = DateTime.Now
            });
            DataBase.Save();
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

        public ArticleDTO Get(int id)
        {
            var article = DataBase.Articles.Get(id);

            if (article == null)
            {
                throw new ValidationException("Article not found", "");
            }

            var articleDto = new ArticleDTO
            {
                Title = article.Title,
                Content = article.Content,
                Category = new CategoryDTO { Id = article.Category.Id, Name = article.Category.Name },
                User = article.User,
                Time = article.Time,
            };

            foreach (var tag in article.Tags)
            {
                articleDto.Tags.Add(new TagDTO { Id = tag.Id, Name = tag.Name });
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
                    Title = article.Title,
                    Content = article.Content,
                    Category = new CategoryDTO { Id = article.Category.Id, Name = article.Category.Name },
                    User = article.User,
                    Time = article.Time,
                };

                foreach (var tag in article.Tags)
                {
                    articleDto.Tags.Add(new TagDTO { Id = tag.Id, Name = tag.Name });
                }

                articlesDTO.Add(articleDto);
            }

            return articlesDTO;
        }

        public void Update(ArticleDTO item)
        {
            var article = DataBase.Articles.Get(item.Id);

            if (article == null)
            {
                throw new ValidationException("Article not found", "");
            }

            article.Title = item.Title;
            article.Content = item.Content;
            article.CategoryId = item.Category.Id;
            article.User = item.User;

            DataBase.Articles.Update(article);
            DataBase.Save();
        }

        public void AddTag(int articleId, int tagId)
        {
            var article = DataBase.Articles.Get(articleId);

            if (article == null)
            {
                throw new ValidationException("Article not found", "");
            }

            var tag = DataBase.Tags.Get(tagId);

            if (tag == null)
            {
                throw new ValidationException("Tag not found", "");
            }

            article.Tags.Add(tag);
            DataBase.Articles.Update(article);
            DataBase.Save();
        }
    }
}
