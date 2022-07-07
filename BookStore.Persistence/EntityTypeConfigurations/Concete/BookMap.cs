using BookStore.Domain.Entities.Concrete;
using BookStore.Persistence.EntityTypeConfigurations.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.EntityTypeConfigurations.Concete
{
    public class BookMap : BaseMap<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.Price).HasPrecision(18, 3).HasConversion<double>().IsRequired(true);

            // Foreign Key
            builder.HasOne(x => x.Genre)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.GenreId)
                .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}