using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Library.Data.DataConstants.DataConstants;

namespace Library.Data.DataModels
{
    [Comment("A book at the library")]
    public class Book
    {
        [Key]
        [Comment("Book identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(BookTitleMaxLength)]
        [Comment("Book title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(BookAuthorMaxLength)]
        [Comment("The book author")]
        public string Author { get; set; } = string.Empty;

        [Required]
        [MaxLength(BookDescMaxLength)]
        [Comment("Book description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Book image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Book rating")]
        public decimal Rating { get; set; }

        [Required]
        [Comment("Book category identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public IList<IdentityUserBook> UsersBooks { get; set; } = new List<IdentityUserBook>();
    }
}

//• Has Id – a unique integer, Primary Key
//• Has Title – a string with min length 10 and max length 50 (required)
//• Has Author – a string with min length 5 and max length 50 (required)
//• Has Description – a string with min length 5 and max length 5000 (required)
//• Has ImageUrl – a string (required)
//• Has Rating – a decimal with min value 0.00 and max value 10.00 (required)
//• Has CategoryId – an integer, foreign key (required)
//• Has Category – a Category (required)
//• Has UsersBooks – a collection of type IdentityUserBook
