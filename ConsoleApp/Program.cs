using DAL.Entity;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            var options = optionsBuilder
                    .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=web3;Trusted_Connection=True;")
                    .Options;

            using (AppDbContext DbContext = new AppDbContext(options))
            {
                Tag tag1 = new Tag() { Name = "math" };
                Tag tag2 = new Tag() { Name = "science" };
                Tag tag3 = new Tag() { Name = "smart" };

                Category category = new Category() { Name = "Science articles" };

                User user = new User() { Login = "ScienceDude2003", Password = "password" };

                DbContext.Users.Add(user);

                DbContext.Tags.Add(tag1);
                DbContext.Tags.Add(tag2);
                DbContext.Tags.Add(tag3);

                DbContext.Categories.Add(category);

                //DbContext.SaveChanges();

                Article article = new Article() { 
                    Title = "First work", 
                    Time = DateTime.Now, 
                    Content = "abcdefgh",
                    Category = category,
                    User = user,
                    Tags = new List<Tag>() { tag1, tag2, tag3 }
                };

                DbContext.Articles.Add(article);

                DbContext.SaveChanges();
            }
        }
    }
}
