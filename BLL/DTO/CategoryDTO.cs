using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"CategoryDTO(Id: {Id}, Name: {Name})";
        }
    }
}
