using Library.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category()
            {
                Id = 1,
                Name = "Action"
            },
            new Category()
            {
                Id = 2,
                Name = "Biography"
            },
            new Category()
            {
                Id = 3,
                Name = "Children"
            },
            new Category()
            {
                Id = 4,
                Name = "Crime"
            },
            new Category()
            {
                Id = 5,
                Name = "Fantasy"
            },
            new Category()
            {
                Id = 6,
                Name = "History"
            },
            new Category()
            {
                Id = 7,
                Name = "IT"
            },
            new Category()
            {
                Id = 8,
                Name = "Science"
            },
            new Category()
            {
                Id = 9,
                Name = "Business and Innovations"
            });
        }
    }
}
