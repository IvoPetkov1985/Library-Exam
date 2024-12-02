using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.DataModels
{
    [Comment("The mapping table between users and books")]
    public class IdentityUserBook
    {
        [Required]
        [Comment("User identifier")]
        public string CollectorId { get; set; } = string.Empty;

        [ForeignKey(nameof(CollectorId))]
        public IdentityUser Collector { get; set; } = null!;

        [Required]
        [Comment("Book identifier")]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;
    }
}
