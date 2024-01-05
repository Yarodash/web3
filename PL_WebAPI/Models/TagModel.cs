using BLL.DTO;
using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
    public class TagModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter tag name.")]
        [MaxLength(32, ErrorMessage = "The length of the tag name must be less than 32 characters.")]
        public string Name { get; set; }

        public static TagModel FromDTO(TagDTO tag)
        {
            return new TagModel
            {
                Id = tag.Id,
                Name = tag.Name,
            };
        }

        public TagDTO ToDTO()
        {
            return new TagDTO
            {
                Name = Name,
            };
        }
    }
}
