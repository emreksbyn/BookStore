using BookStore.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.SeedData
{
    public class SeedBookAuthors : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasData(
              new BookAuthor { Id = 1, BookId = 1, AuthorId = 18 },
              new BookAuthor { Id = 2, BookId = 2, AuthorId = 20 },
              new BookAuthor { Id = 3, BookId = 3, AuthorId = 7 },
              new BookAuthor { Id = 4, BookId = 4, AuthorId = 2 },
              new BookAuthor { Id = 5, BookId = 5, AuthorId = 19 },
              new BookAuthor { Id = 6, BookId = 6, AuthorId = 8 },
              new BookAuthor { Id = 7, BookId = 7, AuthorId = 12 },
              new BookAuthor { Id = 8, BookId = 8, AuthorId = 16 },
              new BookAuthor { Id = 9, BookId = 9, AuthorId = 2 },
              new BookAuthor { Id = 10, BookId = 10, AuthorId = 20 },
              new BookAuthor { Id = 11, BookId = 11, AuthorId = 15 },
              new BookAuthor { Id = 12, BookId = 12, AuthorId = 4 },
              new BookAuthor { Id = 13, BookId = 13, AuthorId = 21 },
              new BookAuthor { Id = 14, BookId = 14, AuthorId = 5 },
              new BookAuthor { Id = 15, BookId = 15, AuthorId = 9 },
              new BookAuthor { Id = 16, BookId = 16, AuthorId = 13 },
              new BookAuthor { Id = 17, BookId = 17, AuthorId = 7 },
              new BookAuthor { Id = 18, BookId = 18, AuthorId = 4 },
              new BookAuthor { Id = 19, BookId = 19, AuthorId = 11 },
              new BookAuthor { Id = 20, BookId = 20, AuthorId = 22 },
              new BookAuthor { Id = 21, BookId = 21, AuthorId = 17 },
              new BookAuthor { Id = 22, BookId = 22, AuthorId = 3 },
              new BookAuthor { Id = 23, BookId = 23, AuthorId = 14 },
              new BookAuthor { Id = 24, BookId = 24, AuthorId = 1 },
              new BookAuthor { Id = 25, BookId = 25, AuthorId = 10 },
              new BookAuthor { Id = 26, BookId = 26, AuthorId = 6 },
              new BookAuthor { Id = 27, BookId = 27, AuthorId = 23 },
              new BookAuthor { Id = 28, BookId = 28, AuthorId = 4 },
              new BookAuthor { Id = 29, BookId = 28, AuthorId = 26 },
              new BookAuthor { Id = 30, BookId = 29, AuthorId = 25 });
        }
    }
}