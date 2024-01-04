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
        public int CategoryId { get; set; }
        public string User { get; set; }
        public IList<int> Tags { get; set; } = new List<int>();

        public override string ToString()
        {
            return $"ArticleDTO(Id: {Id}, Title: {Title}, Content: {Content}, Time: {Time}, CategoryId: {CategoryId}, User: {User}, Tags: [{string.Join(", ", Tags)}])";
        }
    }
}
