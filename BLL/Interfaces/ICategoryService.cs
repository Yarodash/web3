using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ICategoryService : IService<CategoryDTO>
    {
        IEnumerable<ArticleDTO> GetNews(int id);
    }
}
