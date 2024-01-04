using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using BLL.DTO;
using System.Linq;

namespace PL.Models
{
    public class ArticleModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter the title.")]
        [MaxLength(128, ErrorMessage = "The length of the title must be less than 128 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the content.")]
        public string Content { get; set; }

        public DateTime Time { get; set; }

        [Required(ErrorMessage = "Please enter the category ID.")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter the user.")]
        public string User { get; set; }

        public List<int> Tags { get; set; } = new List<int>();

        public static ArticleModel FromDTO(ArticleDTO article)
        {
            return new ArticleModel
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                Time = article.Time,
                CategoryId = article.CategoryId,
                User = article.User,
                Tags = article.Tags.ToList(),
            };
        }

        public ArticleDTO ToDTO()
        {
            return new ArticleDTO
            {
                Title = Title,
                Content = Content,
                Time = new DateTime(),
                CategoryId = CategoryId ?? -1,
                User = User,
                Tags = Tags.ToList(),
            };
        }
    }
}
