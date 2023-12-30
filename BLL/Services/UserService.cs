using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entity;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork DataBase { get; set; }

        public UserService(IUnitOfWork uow)
        {
            DataBase = uow;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var users = DataBase.Users.GetAll();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(users);
        }

        public UserDTO Get(int id)
        {
            var user = DataBase.Users.Get(id);

            if (user == null)
            {
                throw new ValidationException("User not found", "");
            }

            return new UserDTO { Id = user.Id, Login = user.Login };
        }

        public void Register(UserDTO userDTO, string password)
        {
            if (string.IsNullOrWhiteSpace(userDTO.Login))
            {
                throw new ValidationException("Category name cannot be empty or whitespace", "");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ValidationException("Password name cannot be empty or whitespace", "");
            }

            if (password.Length <= 8)
            {
                throw new ValidationException("Password length should be greater than 8", "");
            }

            DataBase.Users.Create(new User { Login = userDTO.Login, Password = password });
            DataBase.Save();
        }

        public void Update(UserDTO item)
        {
            var user = DataBase.Users.Get(item.Id);

            if (user == null)
            {
                throw new ValidationException("User not found", "");
            }

            user.Login = item.Login;
            DataBase.Users.Update(user);
            DataBase.Save();
        }

        public void Delete(int id)
        {
            DataBase.Users.Delete(id);
            DataBase.Save();
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }

        public void Create(UserDTO item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ArticleDTO> IUserService.GetNews(int id)
        {
            var articles = DataBase.Users.Get(id).Articles;

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(articles);
        }
    }
}
