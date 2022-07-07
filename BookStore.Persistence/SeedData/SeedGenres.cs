using BookStore.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.SeedData
{
    public class SeedGenres : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(
             new Genre { Id = "novel", Name = "Novel" },
             new Genre { Id = "memoir", Name = "Memoir" },
             new Genre { Id = "mystery", Name = "Mystery" },
             new Genre { Id = "scifi", Name = "Science Finction" },
             new Genre { Id = "history", Name = "History" });
        }
    }
}