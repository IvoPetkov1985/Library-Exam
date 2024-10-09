using System.ComponentModel.DataAnnotations;
using static Library.Data.DataConstants.DataConstants;

namespace Library.Models.ViewModels
{
    public class AddBookViewModel
    {
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
        public string Rating { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
