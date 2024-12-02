using Library.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Rating)
                .HasPrecision(18, 2);

            builder.HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new Book()
            {
                Id = 1,
                Title = "Lorem Ipsum",
                Author = "Dolor Sit",
                ImageUrl = "https://img.freepik.com/free-psd/book-cover-mock-up-arrangement_23-2148622888.jpg?w=826&t=st=1666106877~exp=1666107477~hmac=5dea3e5634804683bccfebeffdbde98371db37bc2d1a208f074292c862775e1b",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                CategoryId = 1,
                Rating = 9.5m
            },
            new Book()
            {
                Id = 2,
                Title = "Exam Preparations",
                Author = "SoftUni Author",
                ImageUrl = "https://img.freepik.com/free-photo/concept-exams-tests-space-text_185193-79222.jpg?w=1380&t=st=1666039091~exp=1666039691~hmac=f17f061a73cc0d6055208ea2945dccd9ce2112420a552e7e0e9ff1ccbd9b1d52",
                Description = "Sample exams for ASP.NET Fundamentals",
                CategoryId = 7,
                Rating = 10.0m
            });
        }
    }
}
