using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Library.Data.Common.DataConstants;

namespace Library.Data.DataModels
{
    [Comment("Category of the book")]
    public class Category
    {
        [Key]
        [Comment("Category identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [Comment("Category name")]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}
