using BLL.DTO;
using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
    public class CategoryModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter category name.")]
        [MaxLength(128, ErrorMessage = "The length of the category name must be less than 128 characters.")]
        public string Name { get; set; }

        public static CategoryModel FromDTO(CategoryDTO category)
        {
            return new CategoryModel
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public CategoryDTO ToDTO()
        {
            return new CategoryDTO
            {
                Name = Name,
            };
        }
    }
}
