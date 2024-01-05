using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PL.Controllers
{
    [ApiController]
    [Route("api/tags")]
    public class TagsController : ControllerBase
    {
        public ITagService tagService;

        public TagsController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TagModel>> GetAll()
        {
            var tags = tagService.GetAll();
            return Ok(tags.Select(tag => TagModel.FromDTO(tag)));
        }

        [HttpGet("{id}")]
        public ActionResult<TagModel> Get(int id)
        {
            return Ok(TagModel.FromDTO(tagService.Get(id)));
        }

        [HttpGet("{id}/articles")]
        public ActionResult<IEnumerable<ArticleModel>> GetArticles(int id)
        {
            var articles = tagService.GetNews(id);
            return Ok(articles.Select(a => ArticleModel.FromDTO(a)));
        }

        [HttpGet("filter/{partName}")]
        public ActionResult<IEnumerable<TagModel>> GetByPartName(string partName)
        {
            var tags = tagService.GetTags(partName);
            return Ok(tags.Select(tag => TagModel.FromDTO(tag)));
        }

        [HttpPost]
        public ActionResult<TagModel> Post([FromBody] TagModel tag)
        {
            return Ok(tagService.Create(tag.ToDTO()));
        }

        [HttpPut("{id}")]
        public ActionResult<TagModel> Put([FromBody] TagModel tag, int id)
        {
            return Ok(tagService.Update(id, tag.ToDTO()));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            tagService.Delete(id);
            return Ok();
        }
    }
}
