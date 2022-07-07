using BookStore.Domain.Entities.Concrete;
using BookStore.Persistence.EntityTypeConfigurations.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.EntityTypeConfigurations.Concete
{
    public class BookAuthorMap : BaseMap<BookAuthor>
    {
        public override void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            // Composite Key
            builder.HasKey(x => x.Id);
            
            // Foreign Key
            builder.HasOne(x => x.Book)
                .WithMany(x => x.BookAuthors)
                .HasForeignKey(x => x.BookId);

            builder.HasOne(x => x.Author)
                .WithMany(x => x.BookAuthors)
                .HasForeignKey(x => x.AuthorId);
            base.Configure(builder);
        }
    }
}