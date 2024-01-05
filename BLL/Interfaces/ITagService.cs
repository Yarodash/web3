using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ITagService : IService<TagDTO>
    {
        IEnumerable<ArticleDTO> GetNews(int id);
        IEnumerable<TagDTO> GetTags(string partName);
    }
}
