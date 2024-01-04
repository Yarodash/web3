using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
        public CategoryDTO Category { get; set; }
        public string User { get; set; }
        public IList<TagDTO> Tags { get; set; } = new List<TagDTO>();

        public override string ToString()
        {
            return $"ArticleDTO(Id: {Id}, Title: {Title}, Content: {Content}, Time: {Time}, Category: {Category}, User: {User}, Tags: [{string.Join(", ", Tags)}])";
        }
    }
}
