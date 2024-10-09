using System.ComponentModel.DataAnnotations;
using static Library.Data.DataConstants.DataConstants;

namespace Library.Models.ViewModels
{
    public class BookCollectionViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(BookTitleMaxLength, MinimumLength = BookTitleMinLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(BookAuthorMaxLength, MinimumLength = BookAuthorMinLength)]
        public string Author { get; set; } = string.Empty;

        [Required]
        [StringLength(BookDescMaxLength, MinimumLength = BookDescMinLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Url { get; set; } = string.Empty;

        [Required]
        public decimal Rating { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
    }
}
