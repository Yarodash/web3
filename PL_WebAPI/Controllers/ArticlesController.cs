using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Models;
using System.Collections.Generic;
using System.Linq;

namespace PL.Controllers
{
    [ApiController]
    [Route("api/articles")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService articleService;

        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ArticleModel>> GetAll()
        {
            IEnumerable<ArticleDTO> articles = articleService.GetAll();
            return Ok(articles.Select(a => ArticleModel.FromDTO(a)));
        }

        [HttpGet("{id}")]
        public ActionResult<ArticleModel> Get(int id)
        {
            return Ok(ArticleModel.FromDTO(articleService.Get(id)));
        }

        [HttpPost]
        public ActionResult<ArticleModel> Post([FromBody] ArticleModel article)
        {
            return Ok(articleService.Create(article.ToDTO()));
        }

        [HttpPut("{id}")]
        public ActionResult<ArticleModel> Put([FromBody] ArticleModel article, int id)
        {
            return Ok(articleService.Update(id, article.ToDTO()));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            articleService.Delete(id);
            return Ok();
        }
    }
}
