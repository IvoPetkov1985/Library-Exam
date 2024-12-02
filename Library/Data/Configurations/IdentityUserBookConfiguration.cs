using Library.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Data.Configurations
{
    public class IdentityUserBookConfiguration : IEntityTypeConfiguration<IdentityUserBook>
    {
        public void Configure(EntityTypeBuilder<IdentityUserBook> builder)
        {
            builder.HasKey(ub => new
            {
                ub.CollectorId,
                ub.BookId
            });

            builder.HasOne(ub => ub.Book)
                .WithMany(b => b.UsersBooks)
                .HasForeignKey(ub => ub.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
