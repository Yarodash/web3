using BLL.DTO;
using BLL.Infrastructure;
using BLL.Services;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace ConsoleApp
{
    public class Program
    {
        static Services services;

        static void InitServices()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=web3;Trusted_Connection=True;")
                    .Options;

            services = new Services(options);
        }

        static void Wait()
        {
            Console.WriteLine("\n\n\nPress any key to continue");
            Console.ReadLine();
        }

        static void RegisterUser()
        {
            Console.Write("Login: ");
            string login = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            services.UserService.Register(new UserDTO { Login = login }, password);
        }

        static void ShowUsers()
        {
            foreach (var user in services.UserService.GetAll())
            {
                Console.WriteLine("User Id={0} Login={1}", user.Id, user.Login);
            }
        }

        static void DeleteUser()
        {
            Console.Write("User Id: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            services.UserService.Delete(userId);
        }

        static void ChangeUser()
        {
            Console.Write("User Id: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Login: ");
            string login = Console.ReadLine();

            services.UserService.Update(new UserDTO { Id = userId, Login = login });
        }

        static void CreateTag()
        {
            Console.Write("Tag Name: ");
            string tagName = Console.ReadLine();

            services.TagService.Create(new TagDTO { Name = tagName });
        }

        static void ShowTags()
        {
            foreach (var tag in services.TagService.GetAll())
            {
                Console.WriteLine("Tag Id={0} Name={1}", tag.Id, tag.Name);
            }
        }

        static void DeleteTag()
        {
            Console.Write("Tag Id: ");
            int tagId = Convert.ToInt32(Console.ReadLine());

            services.TagService.Delete(tagId);
        }

        static void ChangeTag()
        {
            Console.Write("Tag Id: ");
            int tagId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Tag Name: ");
            string tagName = Console.ReadLine();

            services.TagService.Update(new TagDTO { Id = tagId, Name = tagName });
        }

        static void CreateCategory()
        {
            Console.Write("Category Name: ");
            string categoryName = Console.ReadLine();

            services.CategoryService.Create(new CategoryDTO { Name = categoryName });
        }

        static void ShowCategories()
        {
            foreach (var category in services.CategoryService.GetAll())
            {
                Console.WriteLine("Category Id={0} Name={1}", category.Id, category.Name);
            }
        }

        static void DeleteCategory()
        {
            Console.Write("Category Id: ");
            int categoryId = Convert.ToInt32(Console.ReadLine());

            services.CategoryService.Delete(categoryId);
        }

        static void ChangeCategory()
        {
            Console.Write("Category Id: ");
            int categoryId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Category Name: ");
            string categoryName = Console.ReadLine();

            services.CategoryService.Update(new CategoryDTO { Id = categoryId, Name = categoryName });
        }

        static void CreateArticle()
        {
            Console.Write("Article Title: ");
            string articleTitle = Console.ReadLine();

            Console.Write("Article Content: ");
            string articleContent = Console.ReadLine();

            Console.Write("Article AuthorId: ");
            int authorId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Article CategoryId: ");
            int categoryId = Convert.ToInt32(Console.ReadLine());

            services.ArticleService.Create(new ArticleDTO { 
                Title = articleTitle,
                Content = articleContent,
                User = new UserDTO { Id = authorId },
                Category = new CategoryDTO { Id = categoryId },
            });
        }
        static void AddTagToArticle()
        {
            Console.Write("Article id: ");
            int articleId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Tag id: ");
            int tagId = Convert.ToInt32(Console.ReadLine());

            services.ArticleService.AddTag(articleId, tagId);
        }

        static void ShowArticles()
        {
            foreach (var article in services.ArticleService.GetAll())
            {
                Console.WriteLine("Article #{0} Title={1}\n=====\n{2}\n-----\nCategoryId={3}\nTagIds=[{4}]\nTime={5}\n=====",
                    article.Id,
                    article.Title,
                    article.Content,
                    article.Category,
                    string.Join(", ", article.Tags),
                    article.Time.ToString()
                );
            }
        }

        static void MenuTag()
        {
            Console.Clear();
            Console.WriteLine("Tag Service Menu:");
            Console.WriteLine("1. Create Tag");
            Console.WriteLine("2. Show Tags");
            Console.WriteLine("3. Delete Tag");
            Console.WriteLine("4. Change Tag");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1: CreateTag(); break;
                case 2: ShowTags(); break;
                case 3: DeleteTag(); break;
                case 4: ChangeTag(); break;
            }

            Wait();
        }

        static void MenuCategory()
        {
            Console.Clear();
            Console.WriteLine("Category Service Menu:");
            Console.WriteLine("1. Create Category");
            Console.WriteLine("2. Show Categories");
            Console.WriteLine("3. Delete Category");
            Console.WriteLine("4. Change Category");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1: CreateCategory(); break;
                case 2: ShowCategories(); break;
                case 3: DeleteCategory(); break;
                case 4: ChangeCategory(); break;
            }

            Wait();
        }

        static void MenuUser()
        {
            Console.Clear();
            Console.WriteLine("User Service Menu:");
            Console.WriteLine("1. Register User");
            Console.WriteLine("2. Show Users");
            Console.WriteLine("3. Delete User");
            Console.WriteLine("4. Change User");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1: RegisterUser(); break;
                case 2: ShowUsers(); break;
                case 3: DeleteUser(); break;
                case 4: ChangeUser(); break;
            }

            Wait();
        }

        static void MenuArticle()
        {
            Console.Clear();
            Console.WriteLine("Article Service Menu:");
            Console.WriteLine("1. Create Article");
            Console.WriteLine("2. Add Tag to Article");
            Console.WriteLine("3. Show Articles");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1: CreateArticle(); break;
                case 2: AddTagToArticle(); break;
                case 3: ShowArticles(); break;
            }

            Wait();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Select option:");
            Console.WriteLine("1. Tag service");
            Console.WriteLine("2. Category service");
            Console.WriteLine("3. User service");
            Console.WriteLine("4. Article service");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1: MenuTag(); break;
                case 2: MenuCategory(); break;
                case 3: MenuUser(); break;
                case 4: MenuArticle(); break;
            }
        }

        static void Main(string[] args)
        {
            InitServices();

            while (true)
            {
                Menu();
                /*try
                {
                    Menu();
                } catch (ValidationException e)
                {
                    Console.WriteLine("ERROR", e.msg);
                    Wait();
                }*/
            }
        }
    }
}
