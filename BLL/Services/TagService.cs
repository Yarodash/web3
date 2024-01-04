using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entity;
using DAL.Interfaces;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Services
{
    public class TagService : ITagService
    {
        IUnitOfWork DataBase { get; set; }

        public TagService(IUnitOfWork uow)
        {
            DataBase = uow;
        }

        public IEnumerable<ArticleDTO> GetNews(int id)
        {
            var articles = DataBase.Tags.Get(id).Articles;

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(articles);
        }

        public IEnumerable<TagDTO> GetAll()
        {
            var tags = DataBase.Tags.GetAll();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Tag, TagDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Tag>, List<TagDTO>>(tags);
        }

        public TagDTO Get(int id)
        {
            var tag = DataBase.Tags.Get(id);

            if (tag == null)
            {
                throw new ValidationException("Tag not found");
            }

            return new TagDTO { Id = tag.Id, Name = tag.Name };
        }

        public TagDTO Create(TagDTO item)
        {
            if (string.IsNullOrWhiteSpace(item.Name))
            {
                throw new ValidationException("Tag name cannot be empty or whitespace");
            }

            var tag = new Tag { Name = item.Name };

            DataBase.Tags.Create(tag);
            DataBase.Save();

            return Get(tag.Id);
        }

        public TagDTO Update(int id, TagDTO item)
        {
            var tag = DataBase.Tags.Get(id);

            if (tag == null)
            {
                throw new ValidationException("Tag not found");
            }

            tag.Name = item.Name;
            DataBase.Tags.Update(tag);
            DataBase.Save();

            return Get(id);
        }

        public void Delete(int id)
        {
            DataBase.Tags.Delete(id);
            DataBase.Save();
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
