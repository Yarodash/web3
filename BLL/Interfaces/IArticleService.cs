﻿using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IArticleService : IService<ArticleDTO> 
    {
        void AddTag(int articleId, int tagId);
    }
}
