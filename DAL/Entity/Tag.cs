using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entity
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(32)] 
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
