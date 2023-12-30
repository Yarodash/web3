using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IUserService : IService<UserDTO>
    {
        IEnumerable<ArticleDTO> GetNews(int id);

        void Register(UserDTO userDTO, string password);
    }
}
